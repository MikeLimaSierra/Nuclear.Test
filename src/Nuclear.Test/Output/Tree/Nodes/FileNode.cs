using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class FileNode : TreeNode {

        #region properties

        internal override String Title => Key.FileName;

        #endregion

        #region ctors

        internal FileNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<ITestResultKey> keys = new List<ITestResultKey>();

            if(Verbosity > PrintVerbosity.FileName || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, TestResultKeyPrecisions.MethodName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new MethodNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
