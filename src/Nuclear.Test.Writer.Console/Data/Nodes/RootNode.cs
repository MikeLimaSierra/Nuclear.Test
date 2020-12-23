using System.Collections.Generic;
using System.Linq;

using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Nodes {
    internal class RootNode : TreeNode {

        #region ctors

        internal RootNode(Verbosity verbosity, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results)
            : base("Summary", verbosity, results) {

            if(verbosity > Verbosity.Collapsed || HasFails || HasIgnores || HasBlanks) {
                results
                    .GroupBy((key) => key.Key.AssemblyName)
                    .OrderBy(group => group.Key)
                    .Foreach(group => Children.Add(new AssemblyNode(group.Key, verbosity, group)));
            }
        }

        #endregion

    }
}
