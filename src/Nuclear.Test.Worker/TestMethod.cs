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

        private readonly ParameterInfo[] _parameters;

        private readonly Type[] _genericArguments;

        private readonly ITestResultEndPoint _results;

        private readonly IEnumerable<Attribute> _attributes;

        #endregion

        #region properties

        internal Boolean HasParameters => _parameters.Length > 0;

        internal Boolean IsGeneric => _genericArguments.Length > 0;

        internal String File => _methodInfo.DeclaringType.Name;

        internal String Method => _methodInfo.Name;

        #endregion

        #region ctors

        internal TestMethod(ITestResultEndPoint results, MethodInfo method) {
            Throw.If.Object.IsNull(results, nameof(results));
            Throw.If.Object.IsNull(method, nameof(method));

            _results = results;
            _methodInfo = method;
            _parameters = _methodInfo.GetParameters();
            _genericArguments = _methodInfo.GetGenericArguments();
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

        internal Boolean TryPrepareForInvoke(Object[] @params, out MethodInfo method, out Object[] parameters) {
            method = _methodInfo;
            parameters = @params;

            if(IsGeneric) {
                if(parameters.Length < _genericArguments.Length) {
                    _results.LogError(method, $"Expecting at least {_genericArguments.Length.Format()} parameters that are of type {typeof(Type).Format()}; Given is {parameters.Format()}");
                    return false;
                }

                Object[] typeParams = @params.Take(_genericArguments.Length).ToArray();
                parameters = @params.Skip(_genericArguments.Length).ToArray();

                if(!typeParams.All(tp => tp is Type)) {
                    _results.LogError(method, $"Expecting the first {typeParams.Length.Format()} parameters to be of type {typeof(Type).Format()}; Given is {typeParams.Format()}");
                    return false;
                }

                try {
                    method = _methodInfo.MakeGenericMethod(typeParams.Cast<Type>().ToArray());

                } catch(Exception ex) {
                    _results.LogError(method, $"Making method {_methodInfo.Name.Format()} generic using {typeParams.Format()} didn't work: {ex}");
                    return false;
                }

                _results.AddNote($"Invoking generic method {method.Name}<{String.Join(", ", typeParams.Select(t => t.Format()))}>({String.Join(", ", _parameters.Select(p => p.ParameterType.Format()))})", File, Method);
            }

            return true;
        }

        private void InvokeInternal(Object[] @params) {
            if(TryGetInstance(_methodInfo.DeclaringType, out Object instance) && TryPrepareForInvoke(@params, out MethodInfo method, out Object[] parameters)) {
                if(parameters.Length > 0) {
                    _results.AddNote($"Injecting data set {parameters.Format()}", File, Method);
                }

                try {
                    method.Invoke(instance, parameters);

                } catch(TargetInvocationException ex) {
                    _results.LogError(method, ex.InnerException.ToString());

                } catch(TargetParameterCountException) {
                    _results.LogError(method, $"Parameters mismatch: Expected is {_parameters.Select(p => p.ParameterType).Format()}; Given is {parameters.Select(p => p.FormatType())}");

                } catch(Exception ex) {
                    _results.LogError(method, ex.ToString());
                }
            }
        }

        #endregion

    }
}
