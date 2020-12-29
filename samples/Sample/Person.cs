using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Nuclear.Exceptions;

namespace Sample {
    public class Person : INotifyPropertyChanged {

        #region event

        public event PropertyChangedEventHandler PropertyChanged;

        public event PersonRenamedEventHandler Renamed;

        #endregion

        #region fields

        private String _firstName;

        private String _lastName;

        #endregion

        #region properties

        public String FirstName {
            get => _firstName;
            set {
                Throw.If.String.IsNullOrWhiteSpace(value, nameof(value));

                String old = FullName;
                _firstName = value;
                RaiseRenamed(old);
                RaisePropertyChanged();
            }
        }

        public String LastName {
            get => _lastName;
            set {
                Throw.If.String.IsNullOrWhiteSpace(value, nameof(value));

                String old = FullName;
                _lastName = value;
                RaiseRenamed(old);
                RaisePropertyChanged();
            }
        }

        public String FullName => $"{FirstName} {LastName}";

        #endregion

        #region ctors

        public Person(String firstName, String lastName) {
            Throw.If.String.IsNullOrWhiteSpace(firstName, nameof(firstName));
            Throw.If.String.IsNullOrWhiteSpace(lastName, nameof(lastName));

            _firstName = firstName;
            _lastName = lastName;
        }

        #endregion

        #region methods

        protected void RaisePropertyChanged([CallerMemberName] String propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void RaiseRenamed(String oldName) => Renamed?.Invoke(this, new PersonRenamedEventArgs(oldName, FullName));

        #endregion

    }
}
