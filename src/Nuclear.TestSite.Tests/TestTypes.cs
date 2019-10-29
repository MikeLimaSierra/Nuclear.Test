using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Ntt {

    interface ITwo { }

    interface IZero : ITwo { }

    class Zero : IZero { }

    class DerivesFromZero : Zero { }

    class Two : ITwo { }

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

    class EquatableT : IEquatable<EquatableT> {
        public Boolean Equals(EquatableT other) => _value.Equals(other._value);

        private Int32 _value;
        public EquatableT(Int32 value) { _value = value; }
        public override String ToString() => _value.ToString();
    }

    class ComparableT : IComparable<ComparableT> {
        public Int32 CompareTo(ComparableT other) => _value.CompareTo(other._value);

        private Int32 _value;
        public ComparableT(Int32 value) { _value = value; }
        public override String ToString() => _value.ToString();
    }

    class Comparable : IComparable {
        public Int32 CompareTo(Object obj) => _value.CompareTo((obj as Comparable)._value);

        private Int32 _value;
        public Comparable(Int32 value) { _value = value; }
        public override String ToString() => _value.ToString();
    }

    class ComparableX : IComparable, IComparable<ComparableX> {
        public Int32 CompareTo(ComparableX other) => _value.CompareTo(other._value);
        public Int32 CompareTo(Object obj) => _value.CompareTo((obj as ComparableX)._value);

        private Int32 _value;
        public ComparableX(Int32 value) { _value = value; }
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
