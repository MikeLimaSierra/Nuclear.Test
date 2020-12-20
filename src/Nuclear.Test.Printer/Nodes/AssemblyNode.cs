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

        internal AssemblyNode(Verbosity verbosity, IResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            List<IResultKey> keys = new List<IResultKey>();

            if(Verbosity > Verbosity.TargetFrameworkVersion || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, ResultKeyItems.TargetArchitecture).ToList();

            } else if(verbosity > Verbosity.TargetFrameworkIdentifier) {
                keys = results.GetKeys(Key, ResultKeyItems.TargetFrameworkVersion).ToList();

            } else if(verbosity > Verbosity.AssemblyName) {
                keys = results.GetKeys(Key, ResultKeyItems.TargetFrameworkIdentifier).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new TargetNode(Verbosity, _key, results)));
        }

        #endregion

    }
}
