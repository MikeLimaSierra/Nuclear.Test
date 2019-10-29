using System;
using System.Globalization;

namespace Nuclear.TestSite {
    static class Helper {

        internal static String Print<TType>(this TType _this) {
            if(_this == null) {
                return "null";
            }

            if(_this is Type type) {
                return String.Format(CultureInfo.InvariantCulture, "'{0}'", type.FullName);
            }

            return String.Format(CultureInfo.InvariantCulture, "'{0}'", _this);
        }

        internal static String PrintType(this Object _this) => _this != null ? _this.GetType().Print() : "null";
    }
}
