using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines a serverside communication link.
    /// </summary>
    public interface IServerLink : ILink {

        #region events

        /// <summary>
        /// Is raised when the client has made connection to the output channel.
        /// </summary>
        event EventHandler ClientConnected;

        #endregion

    }
}
