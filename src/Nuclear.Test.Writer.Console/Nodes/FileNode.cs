using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Nodes {
    internal class FileNode : TreeNode {

        #region properties

        internal override String Title => Key.FileName;

        #endregion

        #region ctors

        internal FileNode(Verbosity verbosity, IResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<IResultKey> keys = new List<IResultKey>();

            if(Verbosity > Verbosity.FileName || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, ResultKeyItems.MethodName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new MethodNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
