using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using Nuclear.Exceptions;

namespace Nuclear.Test.NetVersions {

    /// <summary>
    /// A collection of all available .Net implementations currently available.
    /// </summary>
    public enum NetPlatforms : Int32 {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        NETStandard,
        NETFramework,
        NETCore,
        Mono,
        XamarinIOS,
        XamarinMac,
        XamarinAndroid,
        UWP,
        Unity,
        Unknown
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }

    /// <summary>
    /// Offers information about .NETStandard implementations in .NET runtimes.
    /// </summary>
    public class NetVersionTree : Dictionary<(NetPlatforms platform, Version version), Version> {

        #region properties

        /// <summary>
        /// Gets the instance of <see cref="NetVersionTree"/>.
        /// </summary>
        public static NetVersionTree Instance { get; } = new NetVersionTree();

        #endregion

        #region ctors

        private NetVersionTree() {
            Throw.IfNot.Null(Instance, "Instance", "Constructor must not be called twice.");

            Add((NetPlatforms.NETFramework, new Version(4, 5)), new Version(1, 1));
            Add((NetPlatforms.NETFramework, new Version(4, 5, 1)), new Version(1, 2));
            Add((NetPlatforms.NETFramework, new Version(4, 5, 2)), new Version(1, 2));
            Add((NetPlatforms.NETFramework, new Version(4, 6)), new Version(1, 3));
            Add((NetPlatforms.NETFramework, new Version(4, 6, 1)), new Version(2, 0));
            Add((NetPlatforms.NETFramework, new Version(4, 6, 2)), new Version(2, 0));
            Add((NetPlatforms.NETFramework, new Version(4, 7)), new Version(2, 0));
            Add((NetPlatforms.NETFramework, new Version(4, 7, 1)), new Version(2, 0));
            Add((NetPlatforms.NETFramework, new Version(4, 7, 2)), new Version(2, 0));
            Add((NetPlatforms.NETFramework, new Version(4, 8)), new Version(2, 0));

            Add((NetPlatforms.NETCore, new Version(1, 0)), new Version(1, 6));
            Add((NetPlatforms.NETCore, new Version(1, 1)), new Version(1, 6));
            Add((NetPlatforms.NETCore, new Version(2, 0)), new Version(2, 0));
            Add((NetPlatforms.NETCore, new Version(2, 1)), new Version(2, 0));
            Add((NetPlatforms.NETCore, new Version(2, 2)), new Version(2, 0));
            Add((NetPlatforms.NETCore, new Version(3, 0)), new Version(2, 0));

            Add((NetPlatforms.Mono, new Version(4, 6)), new Version(1, 6));
            Add((NetPlatforms.Mono, new Version(5, 4)), new Version(2, 0));

            Add((NetPlatforms.XamarinIOS, new Version(10, 0)), new Version(1, 6));
            Add((NetPlatforms.XamarinIOS, new Version(10, 14)), new Version(2, 0));

            Add((NetPlatforms.XamarinMac, new Version(3, 0)), new Version(1, 6));
            Add((NetPlatforms.XamarinMac, new Version(3, 8)), new Version(2, 0));

            Add((NetPlatforms.XamarinAndroid, new Version(7, 0)), new Version(1, 6));
            Add((NetPlatforms.XamarinAndroid, new Version(8, 0)), new Version(2, 0));

            Add((NetPlatforms.UWP, new Version(8, 0)), new Version(1, 4));
            Add((NetPlatforms.UWP, new Version(8, 1)), new Version(1, 2));
            Add((NetPlatforms.UWP, new Version(10, 0)), new Version(1, 4));
            Add((NetPlatforms.UWP, new Version(10, 0, 16299)), new Version(2, 0));

            Add((NetPlatforms.Unity, new Version(2018, 1)), new Version(2, 0));

        }

        #endregion

        #region methods

        /// <summary>
        /// Get the target runtime for the <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The target runtime of the assembly.</returns>
        public static (NetPlatforms platform, Version version) GetTargetRuntimeFromAssembly(Assembly assembly) {

            String frameworkName = assembly.GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName;
            String[] parts = frameworkName.Replace("Version=v", "").Split(new Char[] { ',' });

            if(parts.Length == 2 && Version.TryParse(parts[1], out Version version)) {

                switch(parts[0]) {
                    case ".NETFramework":
                        return (NetPlatforms.NETFramework, version);
                    case ".NETCoreApp":
                        return (NetPlatforms.NETCore, version);
                    case ".NETStandard":
                        return (NetPlatforms.NETStandard, version);
                    default:
                        return (NetPlatforms.Unknown, version);
                }
            }

            return (NetPlatforms.Unknown, new Version());
        }

        /// <summary>
        /// Get a list of matching target runtimes for the <paramref name="targetRuntime"/>.
        /// </summary>
        /// <param name="targetRuntime">The target runtime for which support is required.</param>
        /// <returns>A list of matching target runtimes.</returns>
        public static List<(NetPlatforms platform, Version version)> GetMatchingTargetRuntimes((NetPlatforms platform, Version version) targetRuntime) {
            if(targetRuntime.platform == NetPlatforms.NETStandard) {
                return Instance.Keys.Where(key => Instance[key] >= targetRuntime.version).ToList();
            } else {
                return Instance.Keys.Where(key => key.platform == targetRuntime.platform && key.version >= targetRuntime.version).ToList();
            }
        }

        #endregion

    }
}
