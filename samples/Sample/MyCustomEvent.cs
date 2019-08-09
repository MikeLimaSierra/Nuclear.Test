using System;
using System.Xml.Linq;

namespace Sample {

    public delegate void MyCustomEventHandler(Object sender, MyCustomEventArgs e);

    public class MyCustomEventArgs : EventArgs {

        public DateTime WakeTimeStamp { get; private set; }

        public DateTime CallTimeStamp { get; private set; }

        public XDocument XmlDoc { get; private set; }

        public MyCustomEventArgs(DateTime wakeTimeStamp, DateTime callTimeStamp, XDocument xmlDoc) {
            WakeTimeStamp = wakeTimeStamp;
            CallTimeStamp = callTimeStamp;
            XmlDoc = xmlDoc;
        }

    }
}
