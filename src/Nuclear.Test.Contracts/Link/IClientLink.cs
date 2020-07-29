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

        #endregion

    }
}
