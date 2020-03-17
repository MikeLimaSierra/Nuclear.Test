using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class AssemblyNode : TreeNode {

        #region properties

        internal override String Title => Key.AssemblyName;

        #endregion

        #region ctors

        internal AssemblyNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(Verbosity > PrintVerbosity.TargetFrameworkVersion || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetArchitecture).ToList();

            } else if(verbosity > PrintVerbosity.TargetFrameworkIdentifier) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetFrameworkVersion).ToList();

            } else if(verbosity > PrintVerbosity.AssemblyName) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetFrameworkIdentifier).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new TargetNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
