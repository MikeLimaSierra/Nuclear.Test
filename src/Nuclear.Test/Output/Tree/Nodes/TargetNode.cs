using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class TargetNode : TreeNode {

        #region properties

        internal override String Title {
            get {
                switch(Key.Precision) {
                    case TestResultKeyPrecisions.TargetArchitecture:
                        return $"{Key.TargetFrameworkIdentifier} v{Key.TargetFrameworkVersion} [{Key.TargetArchitecture}]";

                    case TestResultKeyPrecisions.TargetFrameworkVersion:
                        return $"{Key.TargetFrameworkIdentifier} v{Key.TargetFrameworkVersion}";

                    default:
                        return $"{Key.TargetFrameworkIdentifier}";
                }
            }
        }

        #endregion

        #region ctors

        internal TargetNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(Verbosity > PrintVerbosity.ExecutionFrameworkVersion || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionArchitecture).ToList();

            } else if(verbosity > PrintVerbosity.ExecutionFrameworkIdentifier) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionFrameworkVersion).ToList();

            } else if(verbosity > PrintVerbosity.TargetArchitecture) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionFrameworkIdentifier).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new ExecutionNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
