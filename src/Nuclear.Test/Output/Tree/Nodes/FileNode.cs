using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class FileNode : TreeNode {

        #region properties

        internal override Int32 Padding => 8;

        internal override String Title => Key.FileName;

        internal List<TreeNode> Nodes { get; } = new List<TreeNode>();

        #endregion

        #region ctors

        internal FileNode(PrintVerbosity verbosity, TestResultKey key, ITestResultsSource results)
            : base(verbosity, key, results) {

            List<TestResultKey> keys = new List<TestResultKey>();

            if(Verbosity > PrintVerbosity.FileName || Failed) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.MethodName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Nodes.Add(new MethodNode(Verbosity, _key, results)));
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
