using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Results;
using Nuclear.TestSite;

namespace Nuclear.Test.Worker {
    internal class TestMethod {

        #region fields

        private readonly MethodInfo _methodInfo;

        private readonly ParameterInfo[] _methodParameters;

        private readonly ITestResultEndPoint _results;

        private readonly IEnumerable<Attribute> _attributes;

        #endregion

        #region properties

        internal Boolean HasParameters => _methodParameters.Length > 0;

        internal String File => _methodInfo.DeclaringType.Name;

        internal String Method => _methodInfo.Name;

        #endregion

        #region ctors

        internal TestMethod(ITestResultEndPoint results, MethodInfo method) {
            Throw.If.Object.IsNull(results, nameof(results));
            Throw.If.Object.IsNull(method, nameof(method));

            _results = results;
            _methodInfo = method;
            _methodParameters = _methodInfo.GetParameters();
            _attributes = _methodInfo.GetCustomAttributes().Where(attr => attr is TestDataAttribute || attr is TestParametersAttribute);
        }

        #endregion

        #region methods

        internal void Invoke() {
            _results.PrepareResults(_methodInfo);

            if(HasParameters) {
                foreach(Attribute attr in _attributes) {
                    _results.AddNote($"Processing {attr}", File, Method);

                    foreach(Object[] @params in GetData(attr)) {
                        InvokeInternal(@params);
                    }
                }

            } else {
                InvokeInternal(new Object[0]);
            }
        }

        internal Boolean TryGetInstance(Type type, out Object instance) {
            instance = null;

            try {
                instance = Activator.CreateInstance(type, true);

            } catch {
                _results.LogError(_methodInfo, $"Failed to create instance of {type.Format()}");
            }

            return instance != null;
        }

        internal IEnumerable<Object[]> GetData(Attribute attr) {
            if(attr is TestParametersAttribute tpa && tpa.Parameters != null) {
                return new Object[][] { tpa.Parameters };
            }

            if(attr is TestDataAttribute tda) {
                Type providerType = tda.Provider ?? _methodInfo.DeclaringType;
                String providerMember = tda.ProviderMember;

                if(providerMember != null) {
                    MemberInfo[] candidates = providerType.GetMember(providerMember,
                        MemberTypes.Field | MemberTypes.Property | MemberTypes.Method,
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

                    foreach(MemberInfo candidate in candidates) {
                        if(TryGetData(candidate, out IEnumerable<Object[]> data)) {
                            return data;
                        }
                    }

                } else if(TryGetInstance(providerType, out Object instance) && instance is IEnumerable<Object[]> enumerable) {
                    return enumerable;
                }
            }

            return Enumerable.Empty<Object[]>();
        }

        internal Boolean TryGetData(MemberInfo member, out IEnumerable<Object[]> data) {
            data = null;

            if(member is FieldInfo fi) {
                return TryGetData(fi, out data);

            } else if(member is PropertyInfo pi && pi.GetMethod != null) {
                return TryGetData(pi.GetMethod, out data);

            } else if(member is MethodInfo mi) {
                return TryGetData(mi, out data);
            }

            return data != null && data.Count() > 0;
        }

        internal Boolean TryGetData(FieldInfo field, out IEnumerable<Object[]> data) {
            data = null;

            if(field.FieldType == typeof(IEnumerable<Object[]>)) {
                if(field.IsStatic) {
                    data = field.GetValue(null) as IEnumerable<Object[]>;

                } else if(TryGetInstance(field.DeclaringType, out Object instance)) {
                    data = field.GetValue(instance) as IEnumerable<Object[]>;
                }
            }

            return data != null && data.Count() > 0;
        }

        internal Boolean TryGetData(MethodInfo method, out IEnumerable<Object[]> data) {
            data = null;

            if(method.ReturnType == typeof(IEnumerable<Object[]>)) {
                if(method.IsStatic) {
                    data = method.Invoke(null, new Object[0]) as IEnumerable<Object[]>;

                } else if(TryGetInstance(method.DeclaringType, out Object instance)) {
                    data = method.Invoke(instance, new Object[0]) as IEnumerable<Object[]>;
                }
            }

            return data != null && data.Count() > 0;
        }

        private void InvokeInternal(Object[] @params) {
            if(TryGetInstance(_methodInfo.DeclaringType, out Object instance)) {

                if(@params.Length > 0) {
                    _results.AddNote($"Injecting data set {@params.Format()}", File, Method);
                }

                try {
                    _methodInfo.Invoke(instance, @params);

                } catch(TargetInvocationException ex) {
                    _results.LogError(_methodInfo, ex.InnerException.ToString());

                } catch(TargetParameterCountException) {
                    _results.LogError(_methodInfo, $"Parameters mismatch: Expected is {_methodParameters.Select(p => p.ParameterType).Format()}; Given is {@params.Select(p => p.GetType()).Format()}");

                } catch(Exception ex) {
                    _results.LogError(_methodInfo, ex.ToString());
                }
            }
        }

        #endregion

    }
}
