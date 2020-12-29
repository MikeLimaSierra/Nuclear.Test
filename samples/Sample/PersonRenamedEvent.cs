using System;

using Nuclear.Extensions;

namespace Sample {

    public delegate void PersonRenamedEventHandler(Object sender, PersonRenamedEventArgs e);

    public class PersonRenamedEventArgs : ValueChangedEventArgs<String> {

        public PersonRenamedEventArgs(String oldValue, String newValue) : base(oldValue, newValue) { }

    }
}
