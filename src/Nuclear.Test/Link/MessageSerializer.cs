using System;
using System.IO;

using Nuclear.Exceptions;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements a message handler that has capabilities of serializing and deserializing.
    /// </summary>
    internal class MessageSerializer : IMessageSerializer {

        /// <summary>
        /// Serializes an <see cref="IMessage"/> to a byte array.
        /// </summary>
        /// <param name="message">The <see cref="IMessage"/> that is serialized.</param>
        /// <returns>The byte array.</returns>
        public Byte[] Serialize(IMessage message) {
            Throw.If.Object.IsNull(message, nameof(message));

            Byte[] data;

            using(MemoryStream ms = new MemoryStream()) {
                using(BinaryWriter bw = new BinaryWriter(ms)) {
                    bw.Write(message.Command);
                    bw.Write(message.Payload.Length);
                    bw.Write(message.Payload.ToArray());
                }

                data = ms.ToArray();
            }

            return data;
        }

        /// <summary>
        /// Deserializes a byte array into an <see cref="IMessage"/>.
        /// </summary>
        /// <param name="data">The byte array that is deserialized.</param>
        /// <returns>The <see cref="IMessage"/>.</returns>
        public IMessage Deserialize(Byte[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            IMessage message;

            using(MemoryStream ms = new MemoryStream(data)) {
                using(BinaryReader br = new BinaryReader(ms)) {
                    String command = br.ReadString();
                    Byte[] payload = new Byte[br.ReadInt32()];
                    br.Read(payload, 0, payload.Length);

                    Factory.Instance.Create(out message, command);
                    message.Append(payload);
                }
            }

            return message;
        }
    }
}
