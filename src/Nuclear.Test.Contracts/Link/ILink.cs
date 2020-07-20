using System;

namespace Nuclear.Test.Link {

    public interface ILink {

        #region methods

        Boolean Start();

        void Stop();

        Boolean Send(IMessage message);

        Boolean Send(String command, Boolean data);

        Boolean Send(String command, Int32 data);

        Boolean Send(String command, String data);

        #endregion

    }
}
