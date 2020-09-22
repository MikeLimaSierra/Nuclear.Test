using System;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Threading;

using Nuclear.Exceptions;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements the basic communication link.
    /// </summary>
    public abstract class Link : ILink {

        #region events

        /// <summary>
        /// Is raised when an <see cref="IMessage"/> is received through the input channel.
        /// </summary>
        public event MessageReceivedEventHandler MessageReceived;

        #endregion

        #region fields

        private readonly CancellationTokenSource _cancel = new CancellationTokenSource();

        private readonly IMessageSerializer _serializer = new MessageSerializer();

        #region outbound

        private readonly ConcurrentQueue<Byte[]> _messagesOut = new ConcurrentQueue<Byte[]>();

        private readonly AutoResetEvent _messageOutEvent = new AutoResetEvent(false);

        private Thread _messageWriteT;

        private NamedPipeServerStream _outStream;

        private BinaryWriter _outWriter;

        #endregion

        #region inbound

        private readonly ConcurrentQueue<Byte[]> _messagesIn = new ConcurrentQueue<Byte[]>();

        private readonly AutoResetEvent _messageInEvent = new AutoResetEvent(false);

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
        public String PipeIDOut => $"{PipeID}-Out";

        /// <summary>
        /// Gets the ID of the inbound pipe.
        /// </summary>
        public String PipeIDIn => $"{PipeID}-In";

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
        public virtual Boolean Start() {
            try {
                _messageWriteT = new Thread(MessageWriteTS);
                _messageWriteT.Start();
                _outStream.WaitForConnection();

                return true;

            } catch {
                return false;
            }
        }

        /// <summary>
        /// Connects to another <see cref="ILink"/>.
        /// </summary>
        /// <returns>True if successful.</returns>
        public virtual Boolean Connect() {
            try {
                _messageReadT = new Thread(MessageReadTS);
                _messageReadT.Start();
                _inStream.Connect(ConnectionTimeout);

                return true;

            } catch {
                return false;
            }
        }

        /// <summary>
        /// Sends an <see cref="IMessage"/> through the output channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual void Send(IMessage message) {
            if(message != null) {
                _messagesOut.Enqueue(_serializer.Serialize(message));
                _messageOutEvent.Set();
            }
        }

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected virtual void Dispose(Boolean disposing) {
            _cancel.Cancel();

            if(!_disposedValue) {
                if(disposing) {
                    _outStream?.Dispose();
                    _outStream = null;

                    _inStream?.Dispose();
                    _inStream = null;
                }

                _messageOutEvent.Set();
                _messageInEvent.Set();

                _messageWriteT.Join();
                _messageReadT.Join();

                _disposedValue = true;
            }
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        #endregion

        #region protected methods

        /// <summary>
        /// Raises the event <see cref="MessageReceived"/> with the received <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that was received.</param>
        protected internal void RaiseMessageReceived(IMessage message) => MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));

        /// <summary>
        /// Writes a byte array to the outbound pipe using one or more packages.
        /// </summary>
        /// <param name="data">The byte array that is written.</param>
        protected void Write(Byte[] data) {
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
            Byte[] lengthBuffer = new Byte[sizeof(Int32)];
            _inStream.ReadAsync(lengthBuffer, 0, lengthBuffer.Length, _cancel.Token);

            Int32 length = BitConverter.ToInt32(lengthBuffer, 0);

            using(MemoryStream ms = new MemoryStream()) {
                for(Int32 i = 0; i < length; i += UInt16.MaxValue) {
                    Byte[] databuffer = new Byte[Math.Min(length - i, UInt16.MaxValue)];
                    _inReader.Read(databuffer, 0, databuffer.Length);
                    ms.Write(databuffer, 0, databuffer.Length);
                }

                data = ms.ToArray();
            }
        }

        #endregion

        #region private methods

        private void MessageWriteTS() {
            while(!_cancel.IsCancellationRequested) {
                _messageOutEvent.WaitOne();

                if(!_cancel.IsCancellationRequested) {
                    while(_messagesOut.TryDequeue(out Byte[] data)) {
                        Write(data);
                    }
                }
            }
        }

        private void MessageReadTS() {
            while(!_cancel.IsCancellationRequested) {
                Read(out Byte[] data);
                _messagesIn.Enqueue(data);
                _messageInEvent.Set();
            }
        }

        #endregion

    }
}
