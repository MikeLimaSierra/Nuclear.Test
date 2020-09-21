using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines a message handler that has capabilities of serializing and deserializing.
    /// </summary>
    public interface IMessageSerializer {

        /// <summary>
        /// Serializes an <see cref="IMessage"/> to a byte array.
        /// </summary>
        /// <param name="message">The <see cref="IMessage"/> that is serialized.</param>
        /// <returns>The byte array.</returns>
        Byte[] Serialize(IMessage message);

        /// <summary>
        /// Deserializes a byte array into an <see cref="IMessage"/>.
        /// </summary>
        /// <param name="data">The byte array that is deserialized.</param>
        /// <returns>The <see cref="IMessage"/>.</returns>
        IMessage Deserialize(Byte[] data);

    }
}
