using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Nuclear.TestSite;

namespace Ntt {

    #region testing type inheritance

    interface ITwo { }

    interface IZero : ITwo { }

    class Zero : IZero { }

    class DerivesFromZero : Zero { }

    class Two : ITwo { }

    #endregion

    #region tesing events

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

    #endregion

    #region dummy types

    internal class DummyIEquatableT : Dummy, IEquatable<DummyIEquatableT> {
        internal DummyIEquatableT(Int32 value) : base(value) { }

        public Boolean Equals(DummyIEquatableT other) {
            if(other == null) { return false; }

            return Value.Equals(other.Value);
        }

        public override Boolean Equals(Object obj) {
            if(obj is DummyIEquatableT dummy) { return this == dummy; }

            return base.Equals(obj);
        }

        public override Int32 GetHashCode() => base.GetHashCode();

        public static implicit operator DummyIEquatableT(Int32 num) => new DummyIEquatableT(num);

        public static Boolean operator ==(DummyIEquatableT left, DummyIEquatableT right) => new DummyIEqualityComparerT().Equals(left, right);

        public static Boolean operator !=(DummyIEquatableT left, DummyIEquatableT right) => !new DummyIEqualityComparerT().Equals(left, right);
    }

    internal class DummyIComparable : Dummy, IComparable {
        internal DummyIComparable(Int32 value) : base(value) { }

        public Int32 CompareTo(Object obj) => Value.CompareTo((obj as DummyIComparable).Value);

        public static implicit operator DummyIComparable(Int32 num) => new DummyIComparable(num);
    }

    internal class DummyIComparableT : Dummy, IComparable<DummyIComparableT> {
        internal DummyIComparableT(Int32 value) : base(value) { }

        public Int32 CompareTo(DummyIComparableT other) => Value.CompareTo(other.Value);

        public static implicit operator DummyIComparableT(Int32 num) => new DummyIComparableT(num);
    }

    internal class Dummy {
        internal Int32 Value { get; private set; }

        internal Dummy(Int32 value) { Value = value; }

        public override String ToString() => Value.ToString();

        public static implicit operator Dummy(Int32 num) => new Dummy(num);
    }

    #endregion

    #region dummy comparers

    internal class DummyComparer : Comparer<Dummy> {
        public override Int32 Compare(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? 0 : -Compare(y, x);
            }

            return y == null ? 1 : x.Value.CompareTo(y.Value);
        }
    }

    internal class DummyIComparer : IComparer {
        public Int32 Compare(Object x, Object y) {
            if(x == null) {
                return y == null ? 0 : -Compare(y, x);
            }

            return y == null ? 1 : (x as Dummy).Value.CompareTo((y as Dummy).Value);
        }
    }

    internal class DummyIComparerT : IComparer<Dummy> {
        public Int32 Compare(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? 0 : -Compare(y, x);
            }

            return y == null ? 1 : x.Value.CompareTo(y.Value);
        }
    }

    internal class ThrowingComparer : Comparer<Dummy> {
        public override Int32 Compare(Dummy x, Dummy y) => throw new NotImplementedException();
    }

    internal class DummyEqualityComparer : EqualityComparer<Dummy> {
        public override Boolean Equals(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : x.Value.Equals(y.Value);
        }

        public override Int32 GetHashCode(Dummy obj) => (obj as Dummy).Value;
    }

    internal class DummyIEqualityComparer : IEqualityComparer {
        public new Boolean Equals(Object x, Object y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : (x as Dummy).Value.Equals((y as Dummy).Value);
        }

        public Int32 GetHashCode(Object obj) => (obj as Dummy).Value;
    }

    internal class DummyIEqualityComparerT : IEqualityComparer<Dummy> {
        public Boolean Equals(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : x.Value.Equals(y.Value);
        }

        public Int32 GetHashCode(Dummy obj) => obj.Value;
    }

    internal class ThrowingEqualityComparer : EqualityComparer<Dummy> {
        public override Boolean Equals(Dummy x, Dummy y) => throw new NotImplementedException();
        public override Int32 GetHashCode(Dummy obj) => throw new NotImplementedException();
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

    #endregion

}
