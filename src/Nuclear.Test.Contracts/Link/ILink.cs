using System;

namespace Nuclear.Test.Link {

    public interface ILink {

        #region events

        event MessageReceivedEventHandler MessageReceived;

        event EventHandler Connected;

        #endregion

        #region methods

        Boolean Start();

        void Stop();

        Boolean Send(IMessage message);

        #endregion

    }
}
