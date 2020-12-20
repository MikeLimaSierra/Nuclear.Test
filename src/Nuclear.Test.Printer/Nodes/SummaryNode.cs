using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Nodes {
    internal class SummaryNode : TreeNode {

        #region properties

        internal override String Title => "Summary";

        private ITestResultSource Results { get; set; }

        #endregion

        #region ctors

        internal SummaryNode(Verbosity verbosity, IResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            Results = results;

            List<IResultKey> keys = new List<IResultKey>();

            if(Verbosity > Verbosity.Collapsed || HasFails || HasIgnores || HasBlanks) {
                keys = results.GetKeys(Key, ResultKeyItems.AssemblyName).ToList();
            }

            keys.Sort();
            keys.ForEach(_key => Children.Add(new AssemblyNode(Verbosity, _key, results)));
        }

        #endregion

        #region methods

        internal override void Print(Int32 padding) {
            base.Print(padding);

            PrintOverview();
        }

        private void PrintOverview() {
            Console.WriteLine("=> {0} workers running {1} test assemblies with {2} test methods in {3} classes.",
                Results.GetKeys().Select(key => (key.AssemblyName, key.TargetRuntime, key.TargetArchitecture, key.ExecutionRuntime, key.ExecutionArchitecture)).Distinct().Count(),
                Results.GetKeys().Select(key => (key.AssemblyName, key.TargetRuntime, key.TargetArchitecture)).Distinct().Count(),
                Results.GetKeys().Select(key => (key.AssemblyName, key.FileName, key.MethodName)).Distinct().Count(),
                Results.GetKeys().Select(key => (key.AssemblyName, key.FileName)).Distinct().Count());
        }

        #endregion

    }
}
