using System;
using System.Linq;

using Nuclear.Exceptions;

namespace Nuclear.Test.Worker {
    internal class TestDataSet {

        #region fields

        private readonly Object[] _data;

        #endregion

        #region properties

        internal Boolean HasData => ObjectCount > 0;

        internal Int32 ObjectCount => _data.Length;

        internal Int32 LeadingTypeCount { get; }

        #endregion

        #region ctors

        internal TestDataSet(Object[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            _data = data;

            while(_data.Length > LeadingTypeCount && _data.Take(LeadingTypeCount + 1).All(_ => _ is Type)) {
                LeadingTypeCount++;
            }
        }

        #endregion

        #region methods

        internal Boolean GetObjects(out Object[] data) => GetObjects(0, out _, out data);

        internal Boolean GetObjects(UInt32 typeCount, out Type[] types, out Object[] data) {
            types = new Type[0];
            data = new Object[0];

            if(_data.Length >= typeCount && LeadingTypeCount >= typeCount) {
                types = _data.Take((Int32) typeCount).Cast<Type>().ToArray();
                data = _data.Skip((Int32) typeCount).ToArray();
            }

            return types.Length > 0 || data.Length > 0;
        }

        #endregion

    }
}
