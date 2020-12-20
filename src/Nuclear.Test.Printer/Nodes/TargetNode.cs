using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Nodes {
    internal class TargetNode : TreeNode {

        #region properties

        internal override String Title {
            get {
                switch(Key.Precision) {
                    case TestResultKeyPrecisions.TargetArchitecture:
                        return $"{Key.TargetRuntime.Framework} v{Key.TargetRuntime.Version} [{Key.TargetArchitecture}]";

                    case TestResultKeyPrecisions.TargetFrameworkVersion:
                        return $"{Key.TargetRuntime.Framework} v{Key.TargetRuntime.Version}";

                    default:
                        return $"{Key.TargetRuntime.Framework}";
                }
            }
        }

        #endregion

        #region ctors

        internal TargetNode(Verbosity verbosity, IResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<IResultKey> keys = new List<IResultKey>();

            if(Verbosity > Verbosity.ExecutionFrameworkVersion || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionArchitecture).ToList();

            } else if(verbosity > Verbosity.ExecutionFrameworkIdentifier) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionFrameworkVersion).ToList();

            } else if(verbosity > Verbosity.TargetArchitecture) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionFrameworkIdentifier).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new ExecutionNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
