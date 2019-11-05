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

    internal class DummyIEquatableT : Dummy, IEquatable<DummyIEquatableT> {
        internal DummyIEquatableT(Int32 value) : base(value) { }

        public Boolean Equals(DummyIEquatableT other) => Value.Equals(other.Value);
    }

    internal class DummyIComparable : Dummy, IComparable {
        internal DummyIComparable(Int32 value) : base(value) { }

        public Int32 CompareTo(Object obj) => Value.CompareTo((obj as DummyIComparable).Value);
    }

    internal class DummyIComparableT : Dummy, IComparable<DummyIComparableT> {
        internal DummyIComparableT(Int32 value) : base(value) { }

        public Int32 CompareTo(DummyIComparableT other) => Value.CompareTo(other.Value);
    }

    internal class DummyIComparableX : Dummy, IComparable<DummyIComparableX>, IComparable {
        internal DummyIComparableX(Int32 value) : base(value) { }

        public Int32 CompareTo(Object obj) => Value.CompareTo((obj as DummyIComparableX).Value);

        public Int32 CompareTo(DummyIComparableX other) => Value.CompareTo(other.Value);
    }

    internal class Dummy {
        internal Int32 Value { get; private set; }

        internal Dummy(Int32 value) { Value = value; }

        public override String ToString() => Value.ToString();
    }

    internal class DummyEqualityComparer : IEqualityComparer<Dummy> {
        public Boolean Equals(Dummy x, Dummy y) => x.Value.Equals(y.Value);
        public Int32 GetHashCode(Dummy obj) => (obj as Dummy).Value;
    }

}
