using System;
using System.ComponentModel;
using Nuclear.Exceptions;

namespace Sample {
    public class MyClass : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        private String _content;

        public String Content {
            get => _content;
            set {
                _content = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
            }
        }

        public MyClass(String content) {
            Throw.If.Null(content, "content");

            Content = content;
        }

    }
}
