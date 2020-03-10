using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class ExecutionNode : TreeNode {

        #region properties

        internal override Int32 Padding => 6;

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

        internal List<TreeNode> Nodes { get; } = new List<TreeNode>();

        #endregion

        #region ctors

        internal ExecutionNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(verbosity > PrintVerbosity.ExecutionArchitecture || Failed) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.FileName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Nodes.Add(new FileNode(verbosity, _key, results)));
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
