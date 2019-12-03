using System;

namespace Nuclear.Test {
    /// <summary>
    /// Temporary and incomplete dummy collection of .net platforms
    /// </summary>
    public enum FrameworkIdentifiers : Int32 {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        NETStandard,
        NETFramework,
        NETCoreApp,
        Mono,
        XamarinIOS,
        XamarinMac,
        XamarinAndroid,
        UWP,
        Unity,
        Unknown
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
