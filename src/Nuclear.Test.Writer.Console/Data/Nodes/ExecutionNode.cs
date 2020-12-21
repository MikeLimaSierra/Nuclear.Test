using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Nodes {
    internal class ExecutionNode : TreeNode {

        #region ctors

        internal ExecutionNode(String name, Verbosity verbosity, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results)
            : base(name, verbosity, results) {

            if(verbosity > Verbosity.ExecutionArchitecture || HasFails || HasIgnores || HasBlanks) {
                results
                    .GroupBy((key) => key.Key.FileName)
                    .Foreach(group => Children.Add(new FileNode(group.Key, verbosity, group)));
            }
        }

        #endregion

    }
}
