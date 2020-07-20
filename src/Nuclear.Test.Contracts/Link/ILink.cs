using System;

namespace Nuclear.Test.Link {

    public interface ILink {

        #region methods

        Boolean Start();

        void Stop();

        Boolean Send<T>(String command, T data);

        #endregion

    }
}
