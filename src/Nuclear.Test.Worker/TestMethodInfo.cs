using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Test.Worker {
    internal class TestMethodInfo : ITestMethodInfo {

        #region fields

        private readonly MethodInfo _method;

        private readonly ParameterInfo[] _parameters;

        private Int32 _repeatCount = 1;

        private TestMode _testMode = TestMode.Parallel;

        private List<ITestDataSource> _dataSources = new List<ITestDataSource>();

        #endregion

        #region properties

        public String FileName => _method.DeclaringType.Name;

        public String MethodName => _method.Name;

        public Boolean HasParameters => ParameterCount > 0;

        public Int32 ParameterCount => _parameters.Length;

        public Boolean IsGeneric => GenericParameterCount > 0;

        public Int32 GenericParameterCount { get; }

        public Int32 RepeatCount {
            get => _repeatCount;
            set => _repeatCount = IComparableTExtensions.Clamp(value, 1, Int32.MaxValue);
        }

        public TestMode TestMode {
            get => _testMode;
            set => _testMode = Enum.IsDefined(typeof(TestMode), value) ? value : TestMode.Parallel;
        }

        public IEnumerable<ITestDataSource> DataSources => _dataSources;

        #endregion

        #region ctors

        internal TestMethodInfo(MethodInfo method) {
            Throw.If.Object.IsNull(method, nameof(method));

            _method = method;
            _parameters = _method.GetParameters();
            GenericParameterCount = _method.GetGenericArguments().Length;
        }

        #endregion

        #region methods

        public void Invoke(ITestObjectCreator creator, ITestMethodInvoker invoker) => throw new NotImplementedException();

        public void AddData(ITestDataSource dataSource) {
            if(dataSource != null) {
                _dataSources.Add(dataSource);
            }
        }

        #endregion

    }
}
