using System;
using System.IO;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements a message that can be transmitted between <see cref="ILink"/> instances.
    /// </summary>
    public class Message : IMessage {

        #region properties

        /// <summary>
        /// Gets the command.
        /// </summary>
        public String Command { get; }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        public MemoryStream Payload { get; private set; }

        #endregion

        #region ctors

        public Message(String command) {
            Throw.If.String.IsNullOrWhiteSpace(command, nameof(command));

            Command = command;
            Payload = new MemoryStream();
        }

        #endregion

        #region get methods

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Boolean data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadBoolean();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Byte data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadByte();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out SByte data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadSByte();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Char data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadChar();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Int16 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadInt16();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out UInt16 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadUInt16();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Int32 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadInt32();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out UInt32 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadUInt32();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Int64 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadInt64();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out UInt64 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadUInt64();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Single data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadSingle();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Double data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadDouble();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Decimal data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadDecimal();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out String data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadString();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Byte[] data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    Int32 count = br.ReadInt32();
                    data = br.ReadBytes(count);
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Char[] data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    Int32 count = br.ReadInt32();
                    data = br.ReadChars(count);
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        #endregion

        #region append methods

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Boolean data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Byte data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(SByte data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Char data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Int16 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(UInt16 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Int32 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(UInt32 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Int64 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(UInt64 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Single data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Double data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Decimal data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(String data) {
            Throw.If.Object.IsNull(data, nameof(data));

            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Byte[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Char[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            using(BinaryWriter bw = new BinaryWriter(Payload)) {
                bw.Write(data);
            }

            return this;
        }

        #endregion

        #region methods

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override String ToString() => $"{typeof(Message).Format()} ({Command.Format()} => {Payload.Length.Format()} Bytes)";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected virtual void Dispose(Boolean disposing) {
            if(!_disposedValue) {
                if(disposing) {
                    Payload?.Dispose();
                    Payload = null;
                }

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

        #region static creation methods

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command) => new Message(command);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Boolean data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Byte data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, SByte data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Char data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int16 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt16 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int32 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt32 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int64 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt64 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Single data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Double data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Decimal data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, String data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Byte[] data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Char[] data) => new Message(command).Append(data);

        #endregion

    }
}
