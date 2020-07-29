using System;

namespace Nuclear.Test.Link {
    public interface IServerLink : ILink {

        #region events

        event EventHandler ClientConnected;

        #endregion

    }
}
