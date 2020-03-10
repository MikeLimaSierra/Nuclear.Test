using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class AssemblyNode : TreeNode {

        #region properties

        internal override String Title => Key.AssemblyName;

        internal List<TreeNode> Nodes { get; } = new List<TreeNode>();

        #endregion

        #region ctors

        internal AssemblyNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(verbosity > PrintVerbosity.TargetFrameworkVersion || Failed) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetArchitecture).ToList();

            } else if(verbosity > PrintVerbosity.TargetFrameworkIdentifier) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetFrameworkVersion).ToList();

            } else if(verbosity > PrintVerbosity.AssemblyName) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetFrameworkIdentifier).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Nodes.Add(new TargetNode(verbosity, _key, results)));
        }

        #endregion

        #region methods

        internal override void PrintResults(Int32 padding) {
            PrintTitle(padding);
            PrintResult(!Failed);
            PrintDetails(Total, Successes, Fails);
            WriteEOL();

            Nodes.ForEach(node => node.PrintResults(padding + 2));
        }

        #endregion

    }
}
