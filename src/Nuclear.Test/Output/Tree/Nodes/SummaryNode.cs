﻿using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class SummaryNode : TreeNode {

        #region properties

        internal override String Title => "Summary";

        internal List<TreeNode> Nodes { get; } = new List<TreeNode>();

        #endregion

        #region ctors

        internal SummaryNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(verbosity > PrintVerbosity.Collapsed || Failed) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.AssemblyName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Nodes.Add(new AssemblyNode(verbosity, _key, results)));
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
