using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Nodes {
    internal class ExecutionNode : TreeNode {

        #region properties

        internal override String Title {
            get {
                switch(Key.Precision) {
                    case TestResultKeyPrecisions.ExecutionArchitecture:
                        return $"{Key.ExecutionRuntime.Framework} v{Key.ExecutionRuntime.Version} [{Key.ExecutionArchitecture}]";

                    case TestResultKeyPrecisions.ExecutionFrameworkVersion:
                        return $"{Key.ExecutionRuntime.Framework} v{Key.ExecutionRuntime.Version}";

                    default:
                        return $"{Key.ExecutionRuntime.Framework}";
                }
            }
        }

        #endregion

        #region ctors

        internal ExecutionNode(Verbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(Verbosity > Verbosity.ExecutionArchitecture || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.FileName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new FileNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
