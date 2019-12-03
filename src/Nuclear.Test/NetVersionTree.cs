using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using Nuclear.Exceptions;

namespace Nuclear.Test {

    /// <summary>
    /// Offers information about .NETStandard implementations in .NET runtimes.
    /// </summary>
    public class NetVersionTree : Dictionary<(FrameworkIdentifiers platform, Version version), Version> {

        #region properties

        /// <summary>
        /// Gets the instance of <see cref="NetVersionTree"/>.
        /// </summary>
        public static NetVersionTree Instance { get; } = new NetVersionTree();

        #endregion

        #region ctors

        private NetVersionTree() {
            Throw.IfNot.Null(Instance, "Instance", "Constructor must not be called twice.");

            Add((FrameworkIdentifiers.NETFramework, new Version(4, 5)), new Version(1, 1));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new Version(1, 2));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new Version(1, 2));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 6)), new Version(1, 3));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new Version(2, 0));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new Version(2, 0));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 7)), new Version(2, 0));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new Version(2, 0));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new Version(2, 0));
            Add((FrameworkIdentifiers.NETFramework, new Version(4, 8)), new Version(2, 0));

            Add((FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new Version(1, 6));
            Add((FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new Version(1, 6));
            Add((FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new Version(2, 0));
            Add((FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new Version(2, 0));
            Add((FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new Version(2, 0));
            Add((FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new Version(2, 0));

            Add((FrameworkIdentifiers.Mono, new Version(4, 6)), new Version(1, 6));
            Add((FrameworkIdentifiers.Mono, new Version(5, 4)), new Version(2, 0));

            Add((FrameworkIdentifiers.XamarinIOS, new Version(10, 0)), new Version(1, 6));
            Add((FrameworkIdentifiers.XamarinIOS, new Version(10, 14)), new Version(2, 0));

            Add((FrameworkIdentifiers.XamarinMac, new Version(3, 0)), new Version(1, 6));
            Add((FrameworkIdentifiers.XamarinMac, new Version(3, 8)), new Version(2, 0));

            Add((FrameworkIdentifiers.XamarinAndroid, new Version(7, 0)), new Version(1, 6));
            Add((FrameworkIdentifiers.XamarinAndroid, new Version(8, 0)), new Version(2, 0));

            Add((FrameworkIdentifiers.UWP, new Version(8, 0)), new Version(1, 1));
            Add((FrameworkIdentifiers.UWP, new Version(8, 1)), new Version(1, 2));
            Add((FrameworkIdentifiers.UWP, new Version(10, 0)), new Version(1, 4));
            Add((FrameworkIdentifiers.UWP, new Version(10, 0, 16299)), new Version(2, 0));

            Add((FrameworkIdentifiers.Unity, new Version(2018, 1)), new Version(2, 0));

        }

        #endregion

        #region methods

        /// <summary>
        /// Get the target runtime for the <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The target runtime of the assembly.</returns>
        public static (FrameworkIdentifiers platform, Version version) GetTargetRuntimeFromAssembly(Assembly assembly) {

            TargetFrameworkAttribute attr = assembly.GetCustomAttribute<TargetFrameworkAttribute>();

            if(attr != null) {
                String frameworkName = attr.FrameworkName;
                String[] parts = frameworkName.Replace("Version=v", "").Split(new Char[] { ',' });

                if(parts.Length == 2 && Version.TryParse(parts[1], out Version version)) {

                    switch(parts[0]) {
                        case ".NETFramework":
                            return (FrameworkIdentifiers.NETFramework, version);
                        case ".NETCoreApp":
                            return (FrameworkIdentifiers.NETCoreApp, version);
                        case ".NETStandard":
                            return (FrameworkIdentifiers.NETStandard, version);
                        default:
                            return (FrameworkIdentifiers.Unknown, version);
                    }
                }
            }

            return (FrameworkIdentifiers.Unknown, new Version());
        }

        /// <summary>
        /// Get a list of matching target runtimes for the <paramref name="targetRuntime"/>.
        /// </summary>
        /// <param name="targetRuntime">The target runtime for which support is required.</param>
        /// <returns>A list of matching target runtimes.</returns>
        public static List<(FrameworkIdentifiers platform, Version version)> GetMatchingTargetRuntimes((FrameworkIdentifiers platform, Version version) targetRuntime) {
            if(targetRuntime.platform == FrameworkIdentifiers.NETStandard) {
                return Instance.Keys.Where(key => Instance[key] >= targetRuntime.version).ToList();
            } else {
                return Instance.Keys.Where(key => key.platform == targetRuntime.platform && key.version >= targetRuntime.version).ToList();
            }
        }

        #endregion

    }
}
