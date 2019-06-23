using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Exceptions;
using Nuclear.TestSite.Results;

namespace Nuclear.TestSite.Tests {
    public partial class ConditionalTest {

        #region fields

        private ITestResultsEndPoint _results;

        private String _assemblyName;

        private Boolean _invert;

        #endregion

        #region Properties

        internal ITestResultsEndPoint Results {
            get => _results;
            set {
                Throw.If.Null(value, "value");

                _results = value;
            }
        }

        internal ProcessorArchitecture Architecture { get; set; }

        internal String AssemblyName {
            get => _assemblyName;
            set {
                Throw.If.NullOrWhiteSpace(value, "value");
                _assemblyName = value;
            }
        }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ConditionalTest"/> with <see cref="TestResults"/> as result sink.
        /// </summary>
        /// <param name="invert">True if result inversion is desired, false if not.</param>
        public ConditionalTest(Boolean invert = false) : this(TestResults.Instance, invert) { }

        /// <summary>
        /// Creates a new instance of <see cref="ConditionalTest"/> with <paramref name="results"/> as result sink.
        /// </summary>
        /// <param name="results">The result sink to be used.</param>
        /// <param name="invert">True if result inversion is desired, false if not.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="results"/> is null.</exception>
        public ConditionalTest(ITestResultsEndPoint results, Boolean invert = false) {
            Throw.If.Null(results, "results");

            Results = results;
            _invert = invert;
        }

        #endregion

        #region hidden methods

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Boolean Equals(Object obj) => throw new MethodAccessException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Int32 GetHashCode() => throw new MethodAccessException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String ToString() => throw new MethodAccessException("This method is currently out of order.");

        #endregion

        #region private methods

        /// <summary>
        /// Creates a <see cref="TestResult"/> and lets the <see cref="ITestResultsEndPoint"/> collect it.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message.</param>
        /// <param name="_file">The file name where the test method is located.</param>
        /// <param name="_method">The test method name.</param>
        /// <param name="testInstruction">The test instruction.</param>
        /// <param name="testInstructionOverride">The test instruction override.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InternalTest(Boolean condition, String message, String _file, String _method, [CallerMemberName] String testInstruction = null, String testInstructionOverride = null) {
            Boolean adjustedCondition = _invert ? !condition : condition;
            String testInstructionName = String.Format("Test.{0}.{1}", _invert ? "IfNot" : "If", String.IsNullOrWhiteSpace(testInstructionOverride) ? testInstruction : testInstructionOverride);
            TestResult result = new TestResult(adjustedCondition, testInstructionName, message);

            Results.CollectResult(result, Architecture, AssemblyName, Path.GetFileNameWithoutExtension(_file), _method);
        }

        #endregion

    }
}
