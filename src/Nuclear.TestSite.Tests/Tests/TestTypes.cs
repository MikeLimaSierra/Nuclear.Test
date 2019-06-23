using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Ntt {

    interface IInterfaceOne { }

    interface IInterfaceTwo : IInterfaceOne { }

    class ClassZero : IInterfaceTwo { }

    class ClassOne : ClassZero { }

    class ClassTwo : IInterfaceOne { }

    class PropertyChangedClass : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private Boolean _value;
        public Boolean Value {
            get => _value;
            set {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }

    class ImplementsIEquatableT : IEquatable<ImplementsIEquatableT> {
        public Boolean Equals(ImplementsIEquatableT other) => _value.Equals(other._value);

        private Int32 _value;
        public ImplementsIEquatableT(Int32 value) { _value = value; }
        public override String ToString() => _value.ToString();
    }

    class ImplementsIComparableT : IComparable<ImplementsIComparableT> {
        public Int32 CompareTo(ImplementsIComparableT other) => _value.CompareTo(other._value);

        private Int32 _value;
        public ImplementsIComparableT(Int32 value) { _value = value; }
        public override String ToString() => _value.ToString();
    }

    class ImplementsIComparable : IComparable {
        public Int32 CompareTo(Object obj) => _value.CompareTo((obj as ImplementsIComparable)._value);

        private Int32 _value;
        public ImplementsIComparable(Int32 value) { _value = value; }
        public override String ToString() => _value.ToString();
    }

    class ImplementsNone {
        internal Int32 _value;
        public ImplementsNone(Int32 value) { _value = value; }
        public override String ToString() => _value.ToString();
    }

    class TestEqualityComparer : IEqualityComparer<ImplementsNone> {
        public Boolean Equals(ImplementsNone x, ImplementsNone y) => x._value.Equals(y._value);
        public Int32 GetHashCode(ImplementsNone obj) => (obj as ImplementsNone)._value;
    }

}
