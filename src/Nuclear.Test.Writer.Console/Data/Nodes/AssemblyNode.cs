using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Nodes {
    internal class AssemblyNode : TreeNode {

        #region ctors

        internal AssemblyNode(String name, Verbosity verbosity, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results)
            : base(name, verbosity, results) {

            IEnumerable<IGrouping<String, KeyValuePair<IResultKey, ITestMethodResult>>> groups = Enumerable.Empty<IGrouping<String, KeyValuePair<IResultKey, ITestMethodResult>>>();

            if(verbosity > Verbosity.TargetFrameworkVersion || HasFails || HasIgnores || HasBlanks) {
                groups = results.GroupBy((key) => $"{key.Key.TargetRuntime.Framework} v{key.Key.TargetRuntime.Version} [{key.Key.TargetArchitecture}]");

            } else if(verbosity > Verbosity.TargetFrameworkIdentifier) {
                groups = results.GroupBy((key) => $"{key.Key.TargetRuntime.Framework} v{key.Key.TargetRuntime.Version}");

            } else if(verbosity > Verbosity.AssemblyName) {
                groups = results.GroupBy((key) => $"{key.Key.TargetRuntime.Framework}");
            }

            groups.Foreach(group => Children.Add(new TargetNode(group.Key, verbosity, group)));
        }

        #endregion

    }
}
