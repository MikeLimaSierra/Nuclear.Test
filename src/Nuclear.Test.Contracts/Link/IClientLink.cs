using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines a clientside communication link.
    /// </summary>
    public interface IClientLink : ILink {

        #region events

        /// <summary>
        /// Is raised when the server has made connection to the output channel.
        /// </summary>
        event EventHandler ServerConnected;

        /// <summary>
        /// Is raised when connected to the output channel of an <see cref="IServerLink"/>.
        /// </summary>
        event EventHandler ConnectedToServer;

        #endregion

    }
}
