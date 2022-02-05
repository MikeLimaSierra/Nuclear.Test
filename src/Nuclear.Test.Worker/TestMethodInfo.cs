using System;
using System.Collections.Generic;
using System.Reflection;

using log4net;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Test.Worker {
    internal class TestMethodInfo {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(TestMethodInfo));

        private readonly ParameterInfo[] _parameters;

        private Int32 _repeatCount = 1;

        private TestMode _testMode = TestMode.Parallel;

        private List<TestDataSource> _dataSources = new List<TestDataSource>();

        #endregion

        #region properties

        internal MethodInfo Method { get; }

        internal String FileName => Method.DeclaringType.Name;

        internal String MethodName => Method.Name;

        internal Boolean HasParameters => ParameterCount > 0;

        internal Int32 ParameterCount => _parameters.Length;

        internal Boolean IsGeneric => GenericParameterCount > 0;

        internal Int32 GenericParameterCount { get; }

        internal Int32 RepeatCount {
            get => _repeatCount;
            set => _repeatCount = IComparableTExtensions.Clamp(value, 1, Int32.MaxValue);
        }

        internal TestMode TestMode {
            get => _testMode;
            set => _testMode = Enum.IsDefined(typeof(TestMode), value) ? value : TestMode.Parallel;
        }

        internal IEnumerable<TestDataSource> DataSources => _dataSources;

        #endregion

        #region ctors

        internal TestMethodInfo(MethodInfo method) {
            Throw.If.Object.IsNull(method, nameof(method));

            Method = method;
            _parameters = Method.GetParameters();
            GenericParameterCount = Method.GetGenericArguments().Length;
        }

        #endregion

        #region methods

        internal void AddData(TestDataSource dataSource) {
            if(dataSource != null) {
                _dataSources.Add(dataSource);
            }
        }

        #endregion

    }
}
