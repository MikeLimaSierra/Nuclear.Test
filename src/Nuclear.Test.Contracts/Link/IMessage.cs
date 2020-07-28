using System;
using System.IO;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines a message that can be transmitted between <see cref="ILink"/> instances.
    /// </summary>
    public interface IMessage : IDisposable {

        #region properties

        /// <summary>
        /// Gets the command.
        /// </summary>
        String Command { get; }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        MemoryStream Payload { get; }

        #endregion

    }
}
