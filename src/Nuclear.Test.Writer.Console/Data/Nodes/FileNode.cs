using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Nodes {
    internal class FileNode : TreeNode {

        #region ctors

        internal FileNode(String name, Verbosity verbosity, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results)
            : base(name, verbosity, results) {

            if(verbosity > Verbosity.FileName || HasFails || HasIgnores || HasBlanks) {
                results
                    .GroupBy((key) => key.Key.MethodName)
                    .OrderBy(group => group.Key)
                    .Foreach(group => Children.Add(new MethodNode(group.Key, verbosity, group)));
            }
        }

        #endregion

    }
}
