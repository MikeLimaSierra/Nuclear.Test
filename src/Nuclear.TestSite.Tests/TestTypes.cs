using Nuclear.TestSite;
using System;
using System.Collections;
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

        private Boolean _value1;

        private Boolean _value2;

        public Boolean Value1 {
            get => _value1;
            set {
                _value1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value1"));
            }
        }

        public Boolean Value2 {
            get => _value2;
            set {
                _value2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value2"));
            }
        }

        public Boolean Value1And2 {
            set {
                Value1 = value;
                Value2 = value;
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

        public static implicit operator Dummy(Int32 num) => new Dummy(num);
    }

    internal class DummyEqualityComparer : IEqualityComparer {
        public new Boolean Equals(Object x, Object y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : (x as Dummy).Value.Equals((y as Dummy).Value);
        }

        public Int32 GetHashCode(Object obj) => (obj as Dummy).Value;
    }

    internal class DummyEqualityComparerT : IEqualityComparer<Dummy> {
        public Boolean Equals(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : x.Value.Equals(y.Value);
        }

        public Int32 GetHashCode(Dummy obj) => (obj as Dummy).Value;
    }

    internal class ThrowExceptionComparer : IEqualityComparer {
        public new Boolean Equals(Object x, Object y) => throw new NotImplementedException();
        public Int32 GetHashCode(Object obj) => throw new NotImplementedException();
    }

    internal class ThrowExceptionComparerT<T> : IEqualityComparer<T> {
        public Boolean Equals(T x, T y) => throw new NotImplementedException();
        public Int32 GetHashCode(T obj) => throw new NotImplementedException();
    }

    internal class PropertyChangedEventDataEqualityComparer : IEqualityComparer<EventData<PropertyChangedEventArgs>> {

        public Boolean Equals(EventData<PropertyChangedEventArgs> x, EventData<PropertyChangedEventArgs> y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return ReferenceEquals(x.Sender, y.Sender) && x.EventArgs.PropertyName.Equals(y.EventArgs.PropertyName);
        }

        public Int32 GetHashCode(EventData<PropertyChangedEventArgs> obj) => 0;

    }

}
