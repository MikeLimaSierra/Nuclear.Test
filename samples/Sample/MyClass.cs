using System;
using System.ComponentModel;
using System.Xml.Linq;
using Nuclear.Exceptions;

namespace Sample {
    public class MyClass : INotifyPropertyChanged {

        #region events

        public event PropertyChangedEventHandler PropertyChanged;

        public event MyCustomEventHandler TimeStampEvent;

        #endregion

        #region fields

        private static readonly DateTime _wakeTime;

        private String _title;

        #endregion

        #region properties

        public String Title {
            get => _title;
            set {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        #endregion

        #region ctors

        static MyClass() {
            _wakeTime = DateTime.Now;
        }

        public MyClass(String title) {
            Throw.If.Null(title, "title");

            Title = title;
        }

        #endregion

        #region public methods

        public XDocument ToXml() {
            XDocument doc = new XDocument();

            DateTime now = DateTime.Now;

            doc.Add(new XElement(XName.Get("myroot"),
                new XAttribute(XName.Get("mytitle"), Title),
                new XAttribute(XName.Get("calltimestamp"), now.ToString("o")),
                new XAttribute(XName.Get("waketimestamp"), _wakeTime.ToString("o"))));

            TimeStampEvent?.Invoke(this, new MyCustomEventArgs(_wakeTime, now, doc));

            return doc;
        }

        #endregion

    }
}
