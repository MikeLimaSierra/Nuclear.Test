using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Nuclear.Exceptions;
using Nuclear.TestSite.Results;

namespace Nuclear.TestSite.TestSuites {

    /// <summary>
    /// Supplies conditional test instructions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class TestSuiteCollection : TestSuite {

        #region fields

        private ITestResultsEndPoint _results;

        private Boolean _invert;

        #endregion

        #region Properties

        /// <summary>
        /// Test suite with instructions for testing actions.
        /// </summary>
        public ActionTestSuite Action { get; private set; }

        /// <summary>
        /// Test suite with instructions for testing types.
        /// </summary>
        public TypeTestSuite Type { get; private set; }

        /// <summary>
        /// Test suite with instructions for testing objects in general.
        /// </summary>
        public ObjectTestSuite Object { get; private set; }

        /// <summary>
        /// Test suite with instructions for testing strings.
        /// </summary>
        public StringTestSuite String { get; private set; }

        /// <summary>
        /// Test suite with instructions for testing multiple values.
        /// </summary>
        public ValueTestSuite Value { get; private set; }

        /// <summary>
        /// Test suite with instructions for testing enumerations.
        /// </summary>
        public EnumerationTestSuite Enumeration { get; private set; }

        internal ITestResultsEndPoint Results {
            get => _results;
            set {
                Throw.If.Null(value, "value");

                _results = value;
            }
        }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestSuiteCollection"/> with <see cref="TestResults"/> as result sink.
        /// </summary>
        /// <param name="invert">True if result inversion is desired, false if not.</param>
        public TestSuiteCollection(Boolean invert = false) : this(TestResults.Instance, invert) { }

        /// <summary>
        /// Creates a new instance of <see cref="TestSuiteCollection"/> with <paramref name="results"/> as result sink.
        /// </summary>
        /// <param name="results">The result sink to be used.</param>
        /// <param name="invert">True if result inversion is desired, false if not.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="results"/> is null.</exception>
        public TestSuiteCollection(ITestResultsEndPoint results, Boolean invert = false) {
            Throw.If.Null(results, "results");

            Results = results;
            _invert = invert;

            Action = new ActionTestSuite(this);
            Type = new TypeTestSuite(this);
            Object = new ObjectTestSuite(this);
            String = new StringTestSuite(this);
            Value = new ValueTestSuite(this);
            Enumeration = new EnumerationTestSuite(this);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Processes test data to create a result.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message.</param>
        /// <param name="file">The file name where the test method is located.</param>
        /// <param name="method">The test method name.</param>
        /// <param name="testInstruction">The test instruction.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InternalTest(Boolean condition, String message, String file, String method, [CallerMemberName] String testInstruction = null)
            => CreateResult(condition, message, file, method, testInstruction);

        /// <summary>
        /// Fails the calling test.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="file">The file name where the test method is located.</param>
        /// <param name="method">The test method name.</param>
        /// <param name="testInstruction">The test instruction.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void FailTest(String message, String file, String method, [CallerMemberName] String testInstruction = null)
            => InternalFail(message, file, method, testInstruction);

        #endregion

        #region internal methods

        internal void CreateResult(Boolean condition, String message, String testClassPath, String testMethod, String testInstruction, [CallerFilePath] String testSuitePath = null) {
            Boolean adjustedCondition = _invert ? !condition : condition;
            String testSuite = Path.GetFileNameWithoutExtension(testSuitePath);

            Boolean isCollectionMember = testSuite.Equals(typeof(TestSuiteCollection).Name);

            String testInstructionString = System.String.Format("Test.{0}.{1}{2}{3}",
                _invert ? "IfNot" : "If",
                isCollectionMember ? System.String.Empty : testSuite.Substring(0, testSuite.Length - "TestSuite".Length),
                isCollectionMember ? System.String.Empty : ".",
                testInstruction);

            TestResult result = new TestResult(adjustedCondition, testInstructionString, message);

            Results.CollectResult(result, Path.GetFileNameWithoutExtension(testClassPath), testMethod);
        }

        internal void InternalFail(String message, String testClassPath, String testMethod, String testInstruction, [CallerFilePath] String testSuitePath = null)
            => CreateResult(_invert, message, testClassPath, testMethod, testInstruction, testSuitePath);

        #endregion

    }
}
