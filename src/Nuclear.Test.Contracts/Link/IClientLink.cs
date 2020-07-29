using System;

namespace Nuclear.Test.Link {
    public interface IClientLink : ILink {

        #region events

        event EventHandler ServerConnected;

        #endregion

    }
}
