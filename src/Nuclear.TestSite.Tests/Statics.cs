using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Exceptions;
using Nuclear.Test.Results;

namespace Nuclear.TestSite {
    static class Statics {

        #region fields

        internal static TestScenario _scenario = null;

        #endregion

        #region ctors

        static Statics() {
            Assembly _assembly = typeof(Statics).Assembly;
            AssemblyName _assemblyName = _assembly.GetName();

            (FrameworkIdentifiers platform, Version version) testAssemblyInfo = NetVersionTree.GetTargetRuntimeFromAssembly(_assembly);
            Assembly executionAssembly = Assembly.GetEntryAssembly();
            (FrameworkIdentifiers platform, Version version) executionAssemblyInfo = NetVersionTree.GetTargetRuntimeFromAssembly(executionAssembly);

            _scenario = new TestScenario(_assemblyName.Name,
               testAssemblyInfo.platform, testAssemblyInfo.version, _assemblyName.ProcessorArchitecture,
               executionAssemblyInfo.platform, executionAssemblyInfo.version, executionAssembly.GetName().ProcessorArchitecture);
        }

        #endregion

        #region methods

        internal static TestResultKey GetKey([CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
            Throw.If.Null(_scenario, "scenario");
            return new TestResultKey(_scenario, Path.GetFileNameWithoutExtension(_file), _method);
        }

        internal static TestMethodResult GetResults(ITestResultsSource results, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results[GetKey(_file, _method)];

        internal static TestInstructionResult GetResult(ITestResultsSource results, Int32 index, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results[GetKey(_file, _method)].InstructionResults[index];

        internal static TestInstructionResult GetLastResult(ITestResultsSource results, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results[GetKey(_file, _method)].InstructionResults.Last();

        internal static void DDTResultState(Action action, (Int32 count, Boolean result, String message) expected, String instruction,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.IfNot.Action.ThrowsException(action, out Exception ex, _file, _method);

            TestMethodResult results = GetResults(DummyTestResults.Instance, _file, _method);
            TestInstructionResult lastResult = GetLastResult(DummyTestResults.Instance, _file, _method);

            Test.If.Value.Equals(results.InstructionResults.Count, expected.count, _file, _method);
            Test.If.Value.Equals(lastResult.Result, expected.result, _file, _method);
            Test.If.String.StartsWith(lastResult.Message, expected.message, _file, _method);
            Test.If.Value.Equals(lastResult.Instruction, instruction, _file, _method);

        }

        #endregion

    }
}
