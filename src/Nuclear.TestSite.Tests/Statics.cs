﻿using System;
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

        internal static ProcessorArchitecture Architecture { get; }

        internal static String Runtime { get; }

        #endregion

        #region ctors

        static Statics() {
            AssemblyName = typeof(Statics).Assembly.GetName().Name;
            Architecture = typeof(Statics).Assembly.GetName().ProcessorArchitecture;
            Runtime = Assembly.GetEntryAssembly().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName;
        }

        #endregion

        #region methods

        internal static ResultKeyMethodLevel GetKey([CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => new ResultKeyMethodLevel(AssemblyName, Architecture, Runtime, Path.GetFileNameWithoutExtension(_file), _method);

        internal static TestResultCollection GetResults(ITestResultsEndPoint results, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_file, _method), new TestResultCollection());

        internal static TestResult GetResult(ITestResultsEndPoint results, Int32 index, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_file, _method), new TestResultCollection())[index];

        internal static TestResult GetLastResult(ITestResultsEndPoint results, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => results.ResultMap.GetOrAdd(GetKey(_file, _method), new TestResultCollection()).Last();

        #endregion

    }
}