using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class FileNode : TreeNode {

        #region properties

        internal override Int32 Padding => 8;

        internal override String Title => Key.FileName;

        internal List<TreeNode> Nodes { get; } = new List<TreeNode>();

        #endregion

        #region ctors

        internal FileNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(verbosity > PrintVerbosity.FileName || Failed) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.MethodName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Nodes.Add(new MethodNode(verbosity, _key, results)));
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
