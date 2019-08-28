using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Results {
    class TestResultTests {

        [TestMethod]
        void TestResultConstructor() {

            TestResult result = null;

            Test.Note("new TestResult(false, null, null)");
            Test.If.ThrowsException(() => result = new TestResult(false, null, null), out ArgumentNullException argNullEx);
            Test.IfNot.Null(argNullEx);
            Test.If.ValuesEqual(argNullEx.ParamName, "testInstruction");
            Test.If.Null(result);

            Test.Note("new TestResult(false, String.Empty, null)");
            Test.If.ThrowsException(() => result = new TestResult(false, String.Empty, null), out ArgumentException argEx);
            Test.IfNot.Null(argEx);
            Test.If.ValuesEqual(argEx.ParamName, "testInstruction");
            Test.If.Null(result);

            Test.Note("new TestResult(false, \"SomeInstruction\", null)");
            Test.IfNot.ThrowsException(() => result = new TestResult(false, "SomeInstruction", null), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(result);
            Test.If.True(result.Result.HasValue);
            Test.If.False(result.Result);
            Test.If.ValuesEqual(result.TestInstruction, "SomeInstruction");
            Test.If.ValuesEqual(result.Message, null);

            Test.Note("new TestResult(true, \"SomeInstruction\", \"Some message\")");
            Test.IfNot.ThrowsException(() => result = new TestResult(true, "SomeInstruction", "Some message"), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(result);
            Test.If.True(result.Result.HasValue);
            Test.If.True(result.Result);
            Test.If.ValuesEqual(result.TestInstruction, "SomeInstruction");
            Test.If.ValuesEqual(result.Message, "Some message");

        }

        [TestMethod]
        void TestNoteConstructor() {

            TestResult result = null;

            Test.Note("new TestResult(null)");
            Test.If.ThrowsException(() => result = new TestResult(null), out ArgumentNullException argNullEx);
            Test.IfNot.Null(argNullEx);
            Test.If.ValuesEqual(argNullEx.ParamName, "message");
            Test.If.Null(result);

            Test.Note("new TestResult(String.Empty)");
            Test.If.ThrowsException(() => result = new TestResult(String.Empty), out ArgumentException argEx);
            Test.IfNot.Null(argEx);
            Test.If.ValuesEqual(argEx.ParamName, "message");
            Test.If.Null(result);

            Test.Note("new TestResult(\"Some test note\")");
            Test.IfNot.ThrowsException(() => result = new TestResult("Some test note"), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(result);
            Test.If.False(result.Result.HasValue);
            Test.If.Null(result.TestInstruction);
            Test.If.ValuesEqual(result.Message, "Some test note");

        }

    }
}
