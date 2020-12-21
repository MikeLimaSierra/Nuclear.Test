using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Nodes {
    internal class TargetNode : TreeNode {

        #region ctors

        internal TargetNode(String name, Verbosity verbosity, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results)
            : base(name, verbosity, results) {

            IEnumerable<IGrouping<String, KeyValuePair<IResultKey, ITestMethodResult>>> groups = Enumerable.Empty<IGrouping<String, KeyValuePair<IResultKey, ITestMethodResult>>>();

            if(verbosity > Verbosity.ExecutionFrameworkVersion || HasFails || HasIgnores || HasBlanks) {
                groups = results.GroupBy((key) => $"{key.Key.ExecutionRuntime.Framework} v{key.Key.ExecutionRuntime.Version} [{key.Key.ExecutionArchitecture}]");

            } else if(verbosity > Verbosity.ExecutionFrameworkIdentifier) {
                groups = results.GroupBy((key) => $"{key.Key.ExecutionRuntime.Framework} v{key.Key.ExecutionRuntime.Version}");

            } else if(verbosity > Verbosity.TargetArchitecture) {
                groups = results.GroupBy((key) => $"{key.Key.ExecutionRuntime.Framework}");
            }

            groups.Foreach(group => Children.Add(new ExecutionNode(group.Key, verbosity, group)));
        }

        #endregion

    }
}
