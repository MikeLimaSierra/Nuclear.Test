using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Nuclear.TestSite.Results;

namespace Nuclear.TestSite {
    static class Statics {

        #region properties

        internal static String AssemblyName { get; }

        internal static String TargetRuntime { get; }

        internal static ProcessorArchitecture Architecture { get; }

        internal static String ExecutionRuntime { get; }

        #endregion

        #region ctors

        static Statics() {
            AssemblyName = typeof(Statics).Assembly.GetName().Name;
            TargetRuntime = typeof(Statics).Assembly.GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName;
            Architecture = typeof(Statics).Assembly.GetName().ProcessorArchitecture;
            ExecutionRuntime = Assembly.GetEntryAssembly().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName;
        }

        #endregion

        #region methods

        internal static ResultKeyMethodLevel GetKey([CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => new ResultKeyMethodLevel(AssemblyName, TargetRuntime, Architecture, ExecutionRuntime, Path.GetFileNameWithoutExtension(_file), _method);

        internal static TestResultCollection GetResults(ITestResultsEndPoint results, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_file, _method), new TestResultCollection());

        internal static TestResult GetResult(ITestResultsEndPoint results, Int32 index, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_file, _method), new TestResultCollection())[index];

        internal static TestResult GetLastResult(ITestResultsEndPoint results, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_file, _method), new TestResultCollection()).Last();

        internal static void DDTestResultState(Action action, (Int32 count, Boolean result, String message) expected, String instruction,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.IfNot.Action.ThrowsException(action, out Exception ex, _file, _method);

            TestResultCollection results = GetResults(DummyTestResults.Instance, _file, _method);
            TestResult lastResult = GetLastResult(DummyTestResults.Instance, _file, _method);

            Test.If.Values.Equal(results.Count, expected.count, _file, _method);
            Test.If.Values.Equal(lastResult.Result, expected.result, _file, _method);
            Test.If.String.StartsWith(lastResult.Message, expected.message, _file, _method);
            Test.If.Values.Equal(lastResult.TestInstruction, instruction, _file, _method);

        }

        #endregion

    }
}
