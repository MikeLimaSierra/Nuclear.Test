using System;
using System.Collections.Generic;
using System.Text;
using Nuclear.Test.ConsolePrinter.Tree;
using Nuclear.Test.Results;
using Nuclear.Test.Extensions;
using System.Linq;
using Nuclear.Extensions;

namespace Nuclear.Test.Output {
    public class Summary {

        #region properties

        internal ITestResultSource Results { get; private set; }

        #endregion

        #region ctors

        public Summary(ITestResultSource results) {
            Results = results;
        }

        #endregion

        #region methods

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
