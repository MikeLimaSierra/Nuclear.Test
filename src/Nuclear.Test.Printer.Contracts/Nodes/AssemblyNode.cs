using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Nodes {
    internal class AssemblyNode : TreeNode {

        #region properties

        internal override String Title => Key.AssemblyName;

        #endregion

        #region ctors

        internal AssemblyNode(Verbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(Verbosity > Verbosity.TargetFrameworkVersion || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetArchitecture).ToList();

            } else if(verbosity > Verbosity.TargetFrameworkIdentifier) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetFrameworkVersion).ToList();

            } else if(verbosity > Verbosity.AssemblyName) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.TargetFrameworkIdentifier).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new TargetNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
