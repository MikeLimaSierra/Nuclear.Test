using System;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Threading;

using log4net;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements the basic communication link.
    /// </summary>
    internal abstract class Link : ILink {

        #region events

        /// <summary>
        /// Is raised when an <see cref="IMessage"/> is received through the input channel.
        /// </summary>
        public event MessageReceivedEventHandler MessageReceived;

        #endregion

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Link));

        private readonly IMessageSerializer _serializer = new MessageSerializer();

        #region outbound

        private readonly ConcurrentQueue<Byte[]> _messagesOut = new ConcurrentQueue<Byte[]>();

        private readonly AutoResetEvent _messageOutEvent = new AutoResetEvent(false);

        private readonly CancellationTokenSource _writeCancel = new CancellationTokenSource();

        private Thread _messageWriteT;

        private NamedPipeServerStream _outStream;

        private BinaryWriter _outWriter;

        #endregion

        #region inbound

        private readonly CancellationTokenSource _readCancel = new CancellationTokenSource();

        private Thread _messageReadT;

        private NamedPipeClientStream _inStream;

        private BinaryReader _inReader;

        #endregion

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the number of milliseconds to wait for the server to respond before the connection to another <see cref="ILink"/> times out.
        /// </summary>
        public Int32 ConnectionTimeout { get; set; }

        /// <summary>
        /// Gets the ID that both inbound and outbound pipe IDs are based on.
        /// </summary>
        public String PipeID { get; }

        /// <summary>
        /// Gets the ID of the outbound pipe.
        /// </summary>
        public abstract String PipeIDOut { get; }

        /// <summary>
        /// Gets the ID of the inbound pipe.
        /// </summary>
        public abstract String PipeIDIn { get; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="Link"/>.
        /// </summary>
        /// <param name="pipeID">The ID that both inbound and outbound pipe IDs are based on.</param>
        public Link(String pipeID) {
            Throw.If.String.IsNullOrWhiteSpace(pipeID, nameof(pipeID));

            PipeID = pipeID;

            _outStream = new NamedPipeServerStream(PipeIDOut, PipeDirection.Out, 1);
            _outWriter = new BinaryWriter(_outStream);
            _inStream = new NamedPipeClientStream(".", PipeIDIn, PipeDirection.In, PipeOptions.None, TokenImpersonationLevel.None);
            _inReader = new BinaryReader(_inStream);
        }

        #endregion

        #region ILink methods

        /// <summary>
        /// Starts the output channel.
        /// </summary>
        /// <returns>True if successful.</returns>
        public virtual Boolean StartOutput() {
            _log.Debug(nameof(StartOutput));

            try {
                _messageWriteT = new Thread(MessageWriteTS);
                _messageWriteT.Start();

                return true;

            } catch(Exception ex) {
                _log.Error("Failed to start link.", ex);

                return false;
            }
        }

        /// <summary>
        /// Stops the output channel.
        /// </summary>
        /// <returns>True if successful.</returns>
        public virtual Boolean StopOutput() {
            _log.Debug(nameof(StopOutput));

            try {
                _writeCancel.Cancel();

                _messageOutEvent.Set();
                _messageWriteT.Join();

                _outStream.WaitForPipeDrain();
                _outWriter.Close();
                _outStream.Dispose();

                return true;

            } catch(Exception ex) {
                _log.Error("Failed to start link.", ex);

                return false;
            }
        }

        /// <summary>
        /// Waits for a connecting <see cref="ILink"/> on the output channel.
        /// </summary>
        /// <returns>True if a connection was established.</returns>
        public virtual Boolean WaitForConnection() {
            _log.Debug(nameof(WaitForConnection));

            try {
                _outStream.WaitForConnection();

                return true;

            } catch(Exception ex) {
                _log.Error("Failed to wait for connection.", ex);

                return false;
            }
        }

        /// <summary>
        /// Connects to the output channel of another <see cref="ILink"/>.
        /// </summary>
        /// <returns>True if successful.</returns>
        public virtual Boolean ConnectInput() {
            _log.Debug(nameof(ConnectInput));

            try {
                _inStream.Connect(ConnectionTimeout);
                _messageReadT = new Thread(MessageReadTS);
                _messageReadT.Start();

                return true;

            } catch(Exception ex) {
                _log.Error("Failed to connect.", ex);

                return false;
            }
        }

        /// <summary>
        /// Disconnects from the output channel of another <see cref="ILink"/>.
        /// </summary>
        /// <returns>True if successful.</returns>
        public virtual Boolean DisconnectInput() => throw new NotImplementedException();

        /// <summary>
        /// Sends an <see cref="IMessage"/> through the output channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual void Send(IMessage message) {
            _log.Debug(nameof(Send));

            if(message != null) {
                _log.Debug($"Sending message {message.Format()}");

                _messagesOut.Enqueue(_serializer.Serialize(message));
                _messageOutEvent.Set();
            }
        }

        /// <summary>
        /// Waits until the output buffer has been emptied.
        /// </summary>
        public void WaitForOutputFlush() {
            _log.Debug(nameof(WaitForOutputFlush));

            SpinWait.SpinUntil(() => _messagesOut.IsEmpty);

            _log.Debug("Output flush complete.");
        }

        /// <summary>
        /// Stops all threads.
        /// </summary>
        public void Stop() { }

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

        protected virtual void Dispose(Boolean disposing) {
            _log.Debug(nameof(Dispose));

            _readCancel.Cancel();
            _writeCancel.Cancel();

            if(!_disposedValue) {
                //_messageOutEvent.Set();
                //_messageWriteT.Join();

                //_messageInEvent.Set();
                //_messageForwardT.Join();
                //_messageReadT.Join();

                if(disposing) {
                    _outStream?.Dispose();
                    _outStream = null;

                    _inStream?.Dispose();
                    _inStream = null;

                    _outWriter?.Dispose();
                    _outWriter = null;

                    _inReader?.Dispose();
                    _inReader = null;
                }

                _disposedValue = true;
            }
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Raises the event <see cref="MessageReceived"/> with the received <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that was received.</param>
        protected internal void RaiseMessageReceived(IMessage message) {
            _log.Debug(nameof(RaiseMessageReceived));

            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        }

        /// <summary>
        /// Writes a byte array to the outbound pipe using one or more packages.
        /// </summary>
        /// <param name="data">The byte array that is written.</param>
        protected void Write(Byte[] data) {
            _log.Debug($"{nameof(Write)}({data.Length} Bytes)");

            _outWriter.Write(data.Length);

            for(Int32 i = 0; i < data.Length; i += UInt16.MaxValue) {
                _outWriter.Write(data, i, Math.Min(data.Length - i, UInt16.MaxValue));
            }

            _outWriter.Flush();
        }

        /// <summary>
        /// Reades a byte array from the inbound pipe using one or more packages.
        /// </summary>
        /// <returns>The byte array that is read.</returns>
        protected void Read(out Byte[] data) {
            _log.Debug(nameof(Read));

            Byte[] buffer = new Byte[sizeof(Int32)];
            Int32 byteCount = _inStream.Read(buffer, 0, buffer.Length);

            _log.Debug($"Read {byteCount.Format()} out of expected {buffer.Length.Format()} Bytes.");

            Int32 length = BitConverter.ToInt32(buffer, 0);

            _log.Debug($"Length is {length.Format()}.");

            using(MemoryStream ms = new MemoryStream()) {
                for(Int32 i = 0; i < length; i += UInt16.MaxValue) {
                    buffer = new Byte[Math.Min(length - i, UInt16.MaxValue)];
                    byteCount = _inReader.Read(buffer, 0, buffer.Length);

                    _log.Debug($"Read {byteCount.Format()} out of expected {buffer.Length.Format()} Bytes.");

                    ms.Write(buffer, 0, buffer.Length);
                }

                data = ms.ToArray();
            }
        }

        #endregion

        #region private methods

        private void MessageWriteTS() {
            _log.Debug(nameof(MessageWriteTS));

            while(!_writeCancel.IsCancellationRequested) {
                _messageOutEvent.WaitOne();

                if(!_writeCancel.IsCancellationRequested) {
                    while(_messagesOut.TryDequeue(out Byte[] data)) {
                        Write(data);
                    }
                }
            }

            _log.Debug($"Thread {nameof(MessageWriteTS)} stopped.");
        }

        private void MessageReadTS() {
            _log.Debug(nameof(MessageReadTS));

            while(!_readCancel.IsCancellationRequested) {
                Read(out Byte[] data);

                if(data.Length > 0) {
                    IMessage message = _serializer.Deserialize(data);

                    if(message.Command == Commands.Finished) { _readCancel.Cancel(); }

                    RaiseMessageReceived(message);
                }

                Thread.Sleep(100);
            }

            try {
                _inReader.Close();
                _inStream.Dispose();

            } catch(Exception ex) { _log.Error("Failed to disconnect.", ex); }

            _log.Debug($"Thread {nameof(MessageReadTS)} stopped.");
        }

        #endregion

    }
}
