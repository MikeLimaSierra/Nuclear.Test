using System;
using System.Reflection;

using log4net;

using Nuclear.Creation;
using Nuclear.Exceptions;
using Nuclear.Test.Worker.Factories;

namespace Nuclear.Test.Worker {
    internal class TestMethodInvoker {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(TestMethodInvoker));

        #endregion

        #region properties

        internal TestMethodInfo TestMethod { get; }

        internal ResultsSink ResultsSink { get; }

        #endregion

        #region ctors

        internal TestMethodInvoker(TestMethodInfo testMethod, ResultsSink resultsSink) {
            Throw.If.Object.IsNull(testMethod, nameof(testMethod));
            Throw.If.Object.IsNull(resultsSink, nameof(resultsSink));

            TestMethod = testMethod;
            ResultsSink = resultsSink;
        }

        #endregion

        #region method

        internal void Invoke() {
            _log.Debug(nameof(Invoke));

            for(Int32 i = 0; i < TestMethod.RepeatCount; i++) {
                if(TestMethod.HasParameters || TestMethod.IsGeneric) {
                    foreach(TestDataSource source in TestMethod.DataSources) {
                        foreach(TestDataSet dataSet in source.GetData()) {
                            dataSet.GetObjects((UInt32) TestMethod.GenericParameterCount, out Type[] types, out Object[] data);
                            InvokeInternal(TestMethod.Method, types, data);
                        }
                    }

                } else {
                    InvokeInternal(TestMethod.Method, new Type[0], new Object[0]);
                }
            }
        }

        private void InvokeInternal(MethodInfo method, Type[] genericParameters, Object[] parameters) {
            _log.Debug(nameof(InvokeInternal));

            MethodInfo invokeMethod = genericParameters.Length > 0 ? method.MakeGenericMethod(genericParameters) : method;

            if(Factory.Instance.TestInstances().TryCreate(out Object instance, TestMethod.Method.DeclaringType, out Exception ex)) {
                invokeMethod.Invoke(instance, parameters);

                if(instance is IDisposable disposable) { disposable.Dispose(); }
            }
        }

        #endregion

    }
}
