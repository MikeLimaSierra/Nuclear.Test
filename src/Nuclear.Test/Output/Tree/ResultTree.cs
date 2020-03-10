using System;
using System.Linq;
using Nuclear.Test.ConsolePrinter.Tree.Nodes;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree {
    public class ResultTree {

        #region properties

        internal ITestResultSource Results { get; private set; }

        internal SummaryNode Node { get; private set; }

        #endregion

        #region ctors

        public ResultTree(PrintVerbosity verbosity, ITestResultSource results) {
            Results = results;
            Node = new SummaryNode(verbosity, TestResultKey.Empty, results);
        }

        #endregion

        #region methods

        public void PrintResults() => Node.PrintResults(0);

        public void PrintOverview() {
            Console.WriteLine("=> {0} workers running {1} test assemblies with {2} test methods in {3} classes.",
                Results.GetKeys().Select(key => (key.AssemblyName, key.TargetFrameworkIdentifier, key.TargetFrameworkVersion, key.TargetArchitecture, key.ExecutionFrameworkIdentifier, key.ExecutionFrameworkVersion, key.ExecutionArchitecture)).Distinct().Count(),
                Results.GetKeys().Select(key => (key.AssemblyName, key.TargetFrameworkIdentifier, key.TargetFrameworkVersion, key.TargetArchitecture)).Distinct().Count(),
                Results.GetKeys().Select(key => (key.AssemblyName, key.FileName, key.MethodName)).Distinct().Count(),
                Results.GetKeys().Select(key => (key.AssemblyName, key.FileName)).Distinct().Count());
        }

        #endregion

    }
}
