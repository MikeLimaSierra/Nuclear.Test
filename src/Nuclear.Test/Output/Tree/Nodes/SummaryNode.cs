using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class SummaryNode : TreeNode {

        #region properties

        internal override Int32 Padding => 0;

        internal override String Title => "Summary";

        internal List<TreeNode> Nodes { get; } = new List<TreeNode>();

        #endregion

        #region ctors

        internal SummaryNode(PrintVerbosity verbosity, TestResultKey key, ITestResultsSource results)
            : base(verbosity, key, results) {

            List<TestResultKey> keys = new List<TestResultKey>();

            if(Verbosity > PrintVerbosity.Collapsed || Failed) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.AssemblyName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Nodes.Add(new AssemblyNode(Verbosity, _key, results)));
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
