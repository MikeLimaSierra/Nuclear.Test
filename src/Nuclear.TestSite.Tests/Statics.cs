using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Results;

namespace Nuclear.TestSite {
    static class Statics {

        #region properties

        internal static ProcessorArchitecture Architecture { get; }

        internal static String AssemblyName { get; }

        #endregion

        #region ctors

        static Statics() {
            Architecture = typeof(Statics).Assembly.GetName().ProcessorArchitecture;
            AssemblyName = typeof(Statics).Assembly.GetName().Name;
        }

        #endregion

        #region methods

        internal static Tuple<ProcessorArchitecture, String, String, String> GetKey([CallerFilePath] String _class = null, [CallerMemberName] String _method = null)
            => Tuple.Create(Architecture, AssemblyName, _class.Substring(0, _class.Length - 3).Substring(_class.LastIndexOf('\\') + 1), _method);

        internal static TestResultCollection GetResults(ITestResultsEndPoint results, [CallerFilePath] String _class = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_class, _method), new TestResultCollection());

        internal static TestResult GetResult(ITestResultsEndPoint results, Int32 index, [CallerFilePath] String _class = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_class, _method), new TestResultCollection())[index];

        internal static TestResult GetLastResult(ITestResultsEndPoint results, [CallerFilePath] String _class = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_class, _method), new TestResultCollection()).Last();

        #endregion

    }
}
