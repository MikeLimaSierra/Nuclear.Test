using System;

namespace Nuclear.Test {

    public delegate void TestDataAvailableEventHandler(Object sender, TestDataAvailableEventArgs e);

    public class TestDataAvailableEventArgs : EventArgs {

        #region properties

        public Byte[] Data { get; private set; }

        #endregion

        #region ctors

        public TestDataAvailableEventArgs(Byte[] data) {
            Data = data;
        }

        #endregion

    }
}
