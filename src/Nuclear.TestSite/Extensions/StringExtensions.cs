using System;

namespace Nuclear.TestSite.Extensions {
    internal static class StringExtensions {

        public static Boolean StartsWith(this String _this, Char value) => _this.StartsWith(value.ToString());

        public static Boolean EndsWith(this String _this, Char value) => _this.EndsWith(value.ToString());

    }
}
