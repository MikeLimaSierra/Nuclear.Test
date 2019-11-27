using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class AssemblyNode : TreeNode {

        #region properties

        internal override Int32 Padding => 2;

        internal override String Title => Key.AssemblyName;

        internal List<TreeNode> Nodes { get; } = new List<TreeNode>();

        #endregion

        #region ctors

        internal AssemblyNode(PrintVerbosity verbosity, TestResultKey key, ITestResultsSource results)
            : base(verbosity, key, results) {

            List<TestResultKey> keys = new List<TestResultKey>();

            if(Verbosity > PrintVerbosity.TargetFrameworkVersion || Failed) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetArchitecture).ToList();

            } else if(Verbosity > PrintVerbosity.TargetFrameworkIdentifier) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetFrameworkVersion).ToList();

            } else if(Verbosity > PrintVerbosity.AssemblyName) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetFrameworkIdentifier).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Nodes.Add(new TargetNode(Verbosity, _key, results)));
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
