using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class TargetNode : TreeNode {

        #region properties

        internal override Int32 Padding => 4;

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

        internal List<TreeNode> Nodes { get; } = new List<TreeNode>();

        #endregion

        #region ctors

        internal TargetNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(verbosity > PrintVerbosity.ExecutionFrameworkVersion || Failed) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionArchitecture).ToList();

            } else if(verbosity > PrintVerbosity.ExecutionFrameworkIdentifier) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionFrameworkVersion).ToList();

            } else if(verbosity > PrintVerbosity.TargetArchitecture) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.ExecutionFrameworkIdentifier).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Nodes.Add(new ExecutionNode(verbosity, _key, results)));
        }

        #endregion

        #region methods

        internal override void Print() {
            PrintTitle();
            PrintResult(!Failed);
            PrintDetails(Total, Successes, Fails);
            PrintEOL();

            Nodes.ForEach(node => node.Print());
        }

        #endregion

    }
}
