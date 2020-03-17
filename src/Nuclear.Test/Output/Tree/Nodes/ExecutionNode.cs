using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class ExecutionNode : TreeNode {

        #region properties

        internal override String Title {
            get {
                switch(Key.Precision) {
                    case TestResultKeyPrecisions.ExecutionArchitecture:
                        return $"{Key.ExecutionFrameworkIdentifier} v{Key.ExecutionFrameworkVersion} [{Key.ExecutionArchitecture}]";

                    case TestResultKeyPrecisions.ExecutionFrameworkVersion:
                        return $"{Key.ExecutionFrameworkIdentifier} v{Key.ExecutionFrameworkVersion}";

                    default:
                        return $"{Key.ExecutionFrameworkIdentifier}";
                }
            }
        }

        #endregion

        #region ctors

        internal ExecutionNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(Verbosity > PrintVerbosity.ExecutionArchitecture || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.FileName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new FileNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
