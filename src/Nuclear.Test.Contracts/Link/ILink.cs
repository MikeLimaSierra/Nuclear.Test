using System;

namespace Nuclear.Test.Link {

    public interface ILink {

        #region events

        event MessageReceivedEventHandler MessageReceived;

        #endregion

        #region methods

        Boolean Start();

        void Stop();

        Boolean Send(IMessage message);

        #endregion

    }
}
