using System;
using System.ComponentModel;
using Ntt;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Tests {
    class ConditionalTestTests {

        #region references

        [TestMethod]
        void TestNull() {

            Test.Note("Test.If.Null(null)");
            DummyTest.If.Null(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Object: null]");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.Null");

            Test.Note("Test.If.Null(new Object())");
            DummyTest.If.Null(new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Object: not null]");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.Null");

        }

        [TestMethod]
        void TestNotNull() {

            Test.Note("Test.IfNot.Null(null)");
            DummyTest.IfNot.Null(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Object: null]");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.Null");

            Test.Note("Test.IfNot.Null(new Object())");
            DummyTest.IfNot.Null(new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Object: not null]");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.Null");

        }

        [TestMethod]
        void TestReferencesEqual() {

            Test.Note("Test.If.ReferencesEqual(null, null)");
            DummyTest.If.ReferencesEqual(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

            Test.Note("Test.If.ReferencesEqual(new Object(), null)");
            DummyTest.If.ReferencesEqual(new Object(), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

            Test.Note("Test.If.ReferencesEqual(null, new Object())");
            DummyTest.If.ReferencesEqual(null, new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

            Test.Note("Test.If.ReferencesEqual(new Object(), new Object())");
            DummyTest.If.ReferencesEqual(new Object(), new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

            Test.Note("Test.If.ReferencesEqual(DummyTestResults.Instance, DummyTestResults.Instance)");
            DummyTest.If.ReferencesEqual(DummyTestResults.Instance, DummyTestResults.Instance);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

        }

        [TestMethod]
        void TestNotReferencesEqual() {

            Test.Note("Test.IfNot.ReferencesEqual(null, null)");
            DummyTest.IfNot.ReferencesEqual(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

            Test.Note("Test.IfNot.ReferencesEqual(new Object(), null)");
            DummyTest.IfNot.ReferencesEqual(new Object(), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

            Test.Note("Test.IfNot.ReferencesEqual(null, new Object())");
            DummyTest.IfNot.ReferencesEqual(null, new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

            Test.Note("Test.IfNot.ReferencesEqual(new Object(), new Object())");
            DummyTest.IfNot.ReferencesEqual(new Object(), new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

            Test.Note("Test.IfNot.ReferencesEqual(DummyTestResults.Instance, DummyTestResults.Instance)");
            DummyTest.IfNot.ReferencesEqual(DummyTestResults.Instance, DummyTestResults.Instance);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

        }

        #endregion

        #region exceptions

        [TestMethod]
        void TestThrowsException() {

            Test.Note("Test.If.ThrowsException(() => throw new Exception(\"test message\"), out Exception ex)");
            DummyTest.If.ThrowsException(() => throw new Exception("test message"), out Exception ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.Exception");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            Test.Note("Test.If.ThrowsException(() => throw new ArgumentException(\"test message\"), out ex)");
            DummyTest.If.ThrowsException(() => throw new ArgumentException("test message"), out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.ArgumentException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            Test.Note("Test.If.ThrowsException(() => { }, out ex)");
            DummyTest.If.ThrowsException(() => { }, out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.If.Null(ex);

        }

        [TestMethod]
        void TestNotThrowsException() {

            Test.Note("Test.IfNot.ThrowsException(() => throw new Exception(\"test message\"), out Exception ex)");
            DummyTest.IfNot.ThrowsException(() => throw new Exception("test message"), out Exception ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.Exception");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            Test.Note("Test.IfNot.ThrowsException(() => throw new ArgumentException(\"test message\"), out ex)");
            DummyTest.IfNot.ThrowsException(() => throw new ArgumentException("test message"), out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.ArgumentException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            Test.Note("Test.IfNot.ThrowsException(() => { }, out ex)");
            DummyTest.IfNot.ThrowsException(() => { }, out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.If.Null(ex);

        }

        [TestMethod]
        void TestThrowsExceptionGeneric() {

            Test.Note("Test.If.ThrowsException(() => throw new SystemException(\"test message\"), out SystemException ex)");
            DummyTest.If.ThrowsException(() => throw new SystemException("test message"), out SystemException ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.SystemException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            Test.Note("Test.If.ThrowsException(() => throw new ArgumentException(\"test message\"), out ex)");
            DummyTest.If.ThrowsException(() => throw new ArgumentException("test message"), out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.ArgumentException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            Test.Note("Test.If.ThrowsException(() => throw new ArgumentException(\"test message\"), out NullReferenceException ex_)");
            DummyTest.If.ThrowsException(() => throw new ArgumentException("test message"), out NullReferenceException ex_);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.If.Null(ex_);

            Test.Note("Test.If.ThrowsException(() => { }, out ex)");
            DummyTest.If.ThrowsException(() => { }, out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.If.Null(ex);

        }

        [TestMethod]
        void TestNotThrowsExceptionGeneric() {

            Test.Note("Test.IfNot.ThrowsException(() => throw new SystemException(\"test message\"), out SystemException ex)");
            DummyTest.IfNot.ThrowsException(() => throw new SystemException("test message"), out SystemException ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.SystemException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            Test.Note("Test.IfNot.ThrowsException(() => throw new ArgumentException(\"test message\"), out ex)");
            DummyTest.IfNot.ThrowsException(() => throw new ArgumentException("test message"), out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.ArgumentException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            Test.Note("Test.IfNot.ThrowsException(() => throw new ArgumentException(\"test message\"), out NullReferenceException ex_)");
            DummyTest.IfNot.ThrowsException(() => throw new ArgumentException("test message"), out NullReferenceException ex_);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.If.Null(ex_);

            Test.Note("Test.IfNot.ThrowsException(() => { }, out ex)");
            DummyTest.IfNot.ThrowsException(() => { }, out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.If.Null(ex);

        }

        #endregion

        #region types

        [TestMethod]
        void TestOfType() {

            Test.Note("Test.If.OfType<ClassZero>(null)");
            DummyTest.If.OfType<ClassZero>(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'null'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

            Test.Note("Test.If.OfType<ClassZero>(new ClassZero())");
            DummyTest.If.OfType<ClassZero>(new ClassZero());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassZero'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

            Test.Note("Test.If.OfType<ClassZero>(new ClassOne())");
            DummyTest.If.OfType<ClassZero>(new ClassOne());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassOne'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

            Test.Note("Test.If.OfType<ClassZero>(new ClassTwo())");
            DummyTest.If.OfType<ClassZero>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

            Test.Note("Test.If.OfType<IInterfaceOne>(new ClassTwo())");
            DummyTest.If.OfType<IInterfaceOne>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

        }

        [TestMethod]
        void TestNotOfType() {

            Test.Note("Test.IfNot.OfType<ClassZero>(null)");
            DummyTest.IfNot.OfType<ClassZero>(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'null'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");

            Test.Note("Test.IfNot.OfType<ClassZero>(new ClassZero())");
            DummyTest.IfNot.OfType<ClassZero>(new ClassZero());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassZero'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");

            Test.Note("Test.IfNot.OfType<ClassZero>(new ClassOne())");
            DummyTest.IfNot.OfType<ClassZero>(new ClassOne());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassOne'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");

            Test.Note("Test.IfNot.OfType<ClassZero>(new ClassTwo())");
            DummyTest.IfNot.OfType<ClassZero>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");

            Test.Note("Test.IfNot.OfType<IInterfaceOne>(new ClassTwo())");
            DummyTest.IfNot.OfType<IInterfaceOne>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");
        }

        [TestMethod]
        void TestOfExactType() {

            Test.Note("Test.If.OfExactType<ClassZero>(null)");
            DummyTest.If.OfExactType<ClassZero>(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'null'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfExactType");

            Test.Note("Test.If.OfExactType<ClassZero>(new ClassZero())");
            DummyTest.If.OfExactType<ClassZero>(new ClassZero());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassZero'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfExactType");

            Test.Note("Test.If.OfExactType<ClassZero>(new ClassOne())");
            DummyTest.If.OfExactType<ClassZero>(new ClassOne());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassOne'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfExactType");

            Test.Note("Test.If.OfExactType<ClassZero>(new ClassTwo())");
            DummyTest.If.OfExactType<ClassZero>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfExactType");
        }

        [TestMethod]
        void TestNotOfExactType() {

            Test.Note("Test.IfNot.OfExactType<ClassZero>(null)");
            DummyTest.IfNot.OfExactType<ClassZero>(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'null'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfExactType");

            Test.Note("Test.IfNot.OfExactType<ClassZero>(new ClassZero())");
            DummyTest.IfNot.OfExactType<ClassZero>(new ClassZero());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassZero'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfExactType");

            Test.Note("Test.IfNot.OfExactType<ClassZero>(new ClassOne())");
            DummyTest.IfNot.OfExactType<ClassZero>(new ClassOne());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassOne'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfExactType");

            Test.Note("Test.IfNot.OfExactType<ClassZero>(new ClassTwo())");
            DummyTest.IfNot.OfExactType<ClassZero>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfExactType");
        }

        [TestMethod]
        void TestTypeImplements() {

            Test.Note("Test.If.TypeImplements<ClassZero, ClassZero>()");
            DummyTest.If.TypeImplements<ClassZero, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' is not an interface.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            Test.Note("Test.If.TypeImplements<ClassTwo, IInterfaceOne>()");
            DummyTest.If.TypeImplements<ClassTwo, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassTwo' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            Test.Note("Test.If.TypeImplements<ClassTwo, IInterfaceTwo>()");
            DummyTest.If.TypeImplements<ClassTwo, IInterfaceTwo>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassTwo' doesn't implement interface 'Ntt.IInterfaceTwo'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            Test.Note("Test.If.TypeImplements<ClassZero, IInterfaceOne>()");
            DummyTest.If.TypeImplements<ClassZero, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            Test.Note("Test.If.TypeImplements<IInterfaceTwo, IInterfaceTwo>()");
            DummyTest.If.TypeImplements<IInterfaceTwo, IInterfaceTwo>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceTwo' doesn't implement interface 'Ntt.IInterfaceTwo'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            Test.Note("Test.If.TypeImplements<IInterfaceTwo, IInterfaceOne>()");
            DummyTest.If.TypeImplements<IInterfaceTwo, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceTwo' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");
        }

        [TestMethod]
        void TestNotTypeImplements() {

            Test.Note("Test.IfNot.TypeImplements<ClassZero, ClassZero>()");
            DummyTest.IfNot.TypeImplements<ClassZero, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' is not an interface.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            Test.Note("Test.IfNot.TypeImplements<ClassTwo, IInterfaceOne>()");
            DummyTest.IfNot.TypeImplements<ClassTwo, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassTwo' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            Test.Note("Test.IfNot.TypeImplements<ClassTwo, IInterfaceTwo>()");
            DummyTest.IfNot.TypeImplements<ClassTwo, IInterfaceTwo>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassTwo' doesn't implement interface 'Ntt.IInterfaceTwo'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            Test.Note("Test.IfNot.TypeImplements<ClassZero, IInterfaceOne>()");
            DummyTest.IfNot.TypeImplements<ClassZero, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            Test.Note("Test.IfNot.TypeImplements<IInterfaceTwo, IInterfaceTwo>()");
            DummyTest.IfNot.TypeImplements<IInterfaceTwo, IInterfaceTwo>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceTwo' doesn't implement interface 'Ntt.IInterfaceTwo'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            Test.Note("Test.IfNot.TypeImplements<IInterfaceTwo, IInterfaceOne>()");
            DummyTest.IfNot.TypeImplements<IInterfaceTwo, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceTwo' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

        }

        [TestMethod]
        void TestTypeIsSubclass() {

            Test.Note("Test.If.TypeIsSubClass<ClassZero, ClassZero>()");
            DummyTest.If.TypeIsSubClass<ClassZero, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' is no subclass of 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeIsSubClass");

            Test.Note("Test.If.TypeIsSubClass<ClassOne, ClassZero>()");
            DummyTest.If.TypeIsSubClass<ClassOne, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassOne' is subclass of 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeIsSubClass");

            Test.Note("Test.If.TypeIsSubClass<ClassOne, IInterfaceOne>()");
            DummyTest.If.TypeIsSubClass<ClassOne, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceOne' is not a class.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeIsSubClass");

            Test.Note("Test.If.TypeIsSubClass<IInterfaceOne, ClassZero>()");
            DummyTest.If.TypeIsSubClass<IInterfaceOne, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceOne' is not a class.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeIsSubClass");

        }

        [TestMethod]
        void TestNotTypeIsSubclass() {

            Test.Note("Test.IfNot.TypeIsSubClass<ClassZero, ClassZero>()");
            DummyTest.IfNot.TypeIsSubClass<ClassZero, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' is no subclass of 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeIsSubClass");

            Test.Note("Test.IfNot.TypeIsSubClass<ClassOne, ClassZero>()");
            DummyTest.IfNot.TypeIsSubClass<ClassOne, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassOne' is subclass of 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeIsSubClass");

            Test.Note("Test.IfNot.TypeIsSubClass<ClassOne, IInterfaceOne>()");
            DummyTest.IfNot.TypeIsSubClass<ClassOne, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceOne' is not a class.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeIsSubClass");

            Test.Note("Test.IfNot.TypeIsSubClass<IInterfaceOne, ClassZero>()");
            DummyTest.IfNot.TypeIsSubClass<IInterfaceOne, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceOne' is not a class.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeIsSubClass");

        }

        #endregion

        #region events

        [TestMethod]
        void TestRaisesPropertyChangedEvent() {

            PropertyChangedClass pccObject = new PropertyChangedClass();

            Test.Note("Test.If.RaisesPropertyChangedEvent(null, () => { }, out Object sender, out PropertyChangedEventArgs e)");
            DummyTest.If.RaisesPropertyChangedEvent(null, () => { }, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is null.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesPropertyChangedEvent");

            Test.Note("Test.If.RaisesPropertyChangedEvent(pccObject, () => throw new Exception(), out sender, out e)");
            DummyTest.If.RaisesPropertyChangedEvent(pccObject, () => throw new Exception(), out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Action threw Exception:");
            Test.If.StringContains(Statics.GetLastResult(DummyTestResults.Instance).Message, "System.Exception");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesPropertyChangedEvent");

            Test.Note("Test.If.RaisesPropertyChangedEvent(pccObject, () => { }, out sender, out e)");
            DummyTest.If.RaisesPropertyChangedEvent(pccObject, () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesPropertyChangedEvent");

            Test.Note("Test.If.RaisesPropertyChangedEvent(pccObject, () => pccObject.Value = !pccObject.Value, out sender, out e)");
            DummyTest.If.RaisesPropertyChangedEvent(pccObject, () => pccObject.Value = !pccObject.Value, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesPropertyChangedEvent");
            Test.IfNot.Null(sender);
            Test.If.ReferencesEqual(pccObject, sender);
            Test.IfNot.Null(e);
            Test.If.ValuesEqual(e.PropertyName, "Value");

        }

        [TestMethod]
        void TestNotRaisesPropertyChangedEvent() {

            PropertyChangedClass pccObject = new PropertyChangedClass();

            Test.Note("Test.IfNot.RaisesPropertyChangedEvent(null, () => { }, out Object sender, out PropertyChangedEventArgs e)");
            DummyTest.IfNot.RaisesPropertyChangedEvent(null, () => { }, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is null.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesPropertyChangedEvent");

            Test.Note("Test.IfNot.RaisesPropertyChangedEvent(pccObject, () => throw new Exception(), out sender, out e)");
            DummyTest.IfNot.RaisesPropertyChangedEvent(pccObject, () => throw new Exception(), out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Action threw Exception:");
            Test.If.StringContains(Statics.GetLastResult(DummyTestResults.Instance).Message, "System.Exception");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesPropertyChangedEvent");

            Test.Note("Test.IfNot.RaisesPropertyChangedEvent(pccObject, () => { }, out sender, out e)");
            DummyTest.IfNot.RaisesPropertyChangedEvent(pccObject, () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesPropertyChangedEvent");

            Test.Note("Test.IfNot.RaisesPropertyChangedEvent(pccObject, () => pccObject.Value = !pccObject.Value, out sender, out e)");
            DummyTest.IfNot.RaisesPropertyChangedEvent(pccObject, () => pccObject.Value = !pccObject.Value, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesPropertyChangedEvent");
            Test.IfNot.Null(sender);
            Test.If.ReferencesEqual(pccObject, sender);
            Test.IfNot.Null(e);
            Test.If.ValuesEqual(e.PropertyName, "Value");

        }

        [TestMethod]
        void TestRaisesEvent() {

            PropertyChangedClass pccObject = new PropertyChangedClass();

            Test.Note("Test.If.RaisesEvent(null, \"PropertyChanged\", () => { }, out Object sender, out PropertyChangedEventArgs e)");
            DummyTest.If.RaisesEvent(null, "PropertyChanged", () => { }, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is null.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            Test.Note("Test.If.RaisesEvent(pccObject, \"PropertyChanged\", () => throw new Exception(), out sender, out e)");
            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged", () => throw new Exception(), out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Action threw Exception:");
            Test.If.StringContains(Statics.GetLastResult(DummyTestResults.Instance).Message, "System.Exception");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            Test.Note("Test.If.RaisesEvent(pccObject, \"PropertyChanged\", () => { }, out sender, out e)");
            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged", () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            Test.Note("Test.If.RaisesEvent(pccObject, \"PropertyChanged_\", () => { }, out sender, out e)");
            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged_", () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Event with name 'PropertyChanged_' could not be found.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            Test.Note("Test.If.RaisesEvent(pccObject, \"PropertyChanged\", () => { }, out sender, out DoWorkEventArgs e_)");
            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged", () => { }, out sender, out DoWorkEventArgs e_);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Given type of arguments 'System.ComponentModel.DoWorkEventArgs' doesn't match event handler of type 'System.ComponentModel.PropertyChangedEventHandler'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            Test.Note("Test.If.RaisesEvent(pccObject, \"PropertyChanged\", () => pccObject.Value = !pccObject.Value, out sender, out e)");
            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged", () => pccObject.Value = !pccObject.Value, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");
            Test.IfNot.Null(sender);
            Test.If.ReferencesEqual(pccObject, sender);
            Test.IfNot.Null(e);
            Test.If.ValuesEqual(e.PropertyName, "Value");

        }

        [TestMethod]
        void TestNotRaisesEvent() {

            PropertyChangedClass pccObject = new PropertyChangedClass();

            Test.Note("Test.IfNot.RaisesEvent(null, \"PropertyChanged\", () => { }, out Object sender, out PropertyChangedEventArgs e)");
            DummyTest.IfNot.RaisesEvent(null, "PropertyChanged", () => { }, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is null.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            Test.Note("Test.IfNot.RaisesEvent(pccObject, \"PropertyChanged\", () => throw new Exception(), out sender, out e)");
            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged", () => throw new Exception(), out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Action threw Exception:");
            Test.If.StringContains(Statics.GetLastResult(DummyTestResults.Instance).Message, "System.Exception");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            Test.Note("Test.IfNot.RaisesEvent(pccObject, \"PropertyChanged\", () => { }, out sender, out e)");
            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged", () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            Test.Note("Test.IfNot.RaisesEvent(pccObject, \"PropertyChanged_\", () => { }, out sender, out e)");
            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged_", () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Event with name 'PropertyChanged_' could not be found.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            Test.Note("Test.IfNot.RaisesEvent(pccObject, \"PropertyChanged\", () => { }, out sender, out DoWorkEventArgs e_)");
            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged", () => { }, out sender, out DoWorkEventArgs e_);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Given type of arguments 'System.ComponentModel.DoWorkEventArgs' doesn't match event handler of type 'System.ComponentModel.PropertyChangedEventHandler'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            Test.Note("Test.IfNot.RaisesEvent(pccObject, \"PropertyChanged\", () => pccObject.Value = !pccObject.Value, out sender, out e)");
            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged", () => pccObject.Value = !pccObject.Value, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");
            Test.IfNot.Null(sender);
            Test.If.ReferencesEqual(pccObject, sender);
            Test.IfNot.Null(e);
            Test.If.ValuesEqual(e.PropertyName, "Value");

        }

        #endregion

        #region boolean

        [TestMethod]
        void TestTrue() {

            Test.Note("Test.If.True(true)");
            DummyTest.If.True(true);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'True']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.True");

            Test.Note("Test.If.True(false)");
            DummyTest.If.True(false);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'False']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.True");

            Test.Note("Test.If.True(null)");
            DummyTest.If.True(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.True");

        }

        [TestMethod]
        void TestNotTrue() {

            Test.Note("Test.IfNot.True(true)");
            DummyTest.IfNot.True(true);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'True']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.True");

            Test.Note("Test.IfNot.True(false)");
            DummyTest.IfNot.True(false);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'False']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.True");

            Test.Note("Test.IfNot.True(null)");
            DummyTest.IfNot.True(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.True");

        }

        [TestMethod]
        void TestFalse() {

            Test.Note("Test.If.False(true)");
            DummyTest.If.False(true);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'True']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.False");

            Test.Note("Test.If.False(false)");
            DummyTest.If.False(false);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'False']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.False");

            Test.Note("Test.If.False(null)");
            DummyTest.If.False(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.False");

        }

        [TestMethod]
        void TestNotFalse() {

            Test.Note("Test.IfNot.False(true)");
            DummyTest.IfNot.False(true);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'True']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.False");

            Test.Note("Test.IfNot.False(false)");
            DummyTest.IfNot.False(false);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'False']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.False");

            Test.Note("Test.IfNot.False(null)");
            DummyTest.IfNot.False(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.False");

        }

        #endregion

        #region generic equality

        [TestMethod]
        void TestValuesEqualIEquatableT() {

            Test.Note("Test.If.ValuesEqual<ImplementsIEquatableT>(null, null)");
            DummyTest.If.ValuesEqual<ImplementsIEquatableT>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIEquatableT(0), null)");
            DummyTest.If.ValuesEqual(new ImplementsIEquatableT(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(GenericEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(null, new ImplementsIEquatableT(0)");
            DummyTest.If.ValuesEqual(null, new ImplementsIEquatableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(GenericEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(0)");
            DummyTest.If.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIEquatableT.IEquatable<T>) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(5)");
            DummyTest.If.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIEquatableT.IEquatable<T>) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualIEquatableT() {

            Test.Note("Test.IfNot.ValuesEqual<ImplementsIEquatableT>(null, null)");
            DummyTest.IfNot.ValuesEqual<ImplementsIEquatableT>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIEquatableT(0), null)");
            DummyTest.IfNot.ValuesEqual(new ImplementsIEquatableT(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(GenericEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(null, new ImplementsIEquatableT(0))");
            DummyTest.IfNot.ValuesEqual(null, new ImplementsIEquatableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(GenericEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(0))");
            DummyTest.IfNot.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIEquatableT.IEquatable<T>) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(5))");
            DummyTest.IfNot.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIEquatableT.IEquatable<T>) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");
        }

        [TestMethod]
        void TestValuesEqualIComparableT() {

            Test.Note("Test.If.ValuesEqual<ImplementsIComparableT>(null, null)");
            DummyTest.If.ValuesEqual<ImplementsIComparableT>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIComparableT(0), null)");
            DummyTest.If.ValuesEqual(new ImplementsIComparableT(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(null, new ImplementsIComparableT(0))");
            DummyTest.If.ValuesEqual(null, new ImplementsIComparableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(0))");
            DummyTest.If.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparableT.IComparable<T>) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(5))");
            DummyTest.If.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparableT.IComparable<T>) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualIComparableT() {

            Test.Note("Test.IfNot.ValuesEqual<ImplementsIComparableT>(null, null)");
            DummyTest.IfNot.ValuesEqual<ImplementsIComparableT>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIComparableT(0), null)");
            DummyTest.IfNot.ValuesEqual(new ImplementsIComparableT(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(null, new ImplementsIComparableT(0))");
            DummyTest.IfNot.ValuesEqual(null, new ImplementsIComparableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(0))");
            DummyTest.IfNot.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparableT.IComparable<T>) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(5))");
            DummyTest.IfNot.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparableT.IComparable<T>) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");
        }

        [TestMethod]
        void TestValuesEqualIComparable() {

            Test.Note("Test.If.ValuesEqual<ImplementsIComparable>(null, null)");
            DummyTest.If.ValuesEqual<ImplementsIComparable>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIComparable(0), null)");
            DummyTest.If.ValuesEqual(new ImplementsIComparable(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(null, new ImplementsIComparable(0))");
            DummyTest.If.ValuesEqual(null, new ImplementsIComparable(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(0))");
            DummyTest.If.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparable.IComparable) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(5))");
            DummyTest.If.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparable.IComparable) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualIComparable() {

            Test.Note("Test.IfNot.ValuesEqual<ImplementsIComparable>(null, null)");
            DummyTest.IfNot.ValuesEqual<ImplementsIComparable>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIComparable(0), null)");
            DummyTest.IfNot.ValuesEqual(new ImplementsIComparable(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(null, new ImplementsIComparable(0))");
            DummyTest.IfNot.ValuesEqual(null, new ImplementsIComparable(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(0))");
            DummyTest.IfNot.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparable.IComparable) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(5))");
            DummyTest.IfNot.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparable.IComparable) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");
        }

        [TestMethod]
        void TestValuesEqualEqualityComparerT() {

            Test.Note("Test.If.ValuesEqual<ImplementsNone>(null, null)");
            DummyTest.If.ValuesEqual<ImplementsNone>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsNone(0), null)");
            DummyTest.If.ValuesEqual(new ImplementsNone(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(null, new ImplementsNone(0))");
            DummyTest.If.ValuesEqual(null, new ImplementsNone(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(0))");
            DummyTest.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5))");
            DummyTest.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5), new TestEqualityComparer())");
            DummyTest.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5), new TestEqualityComparer());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(TestEqualityComparer) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualEqualityComparerT() {

            Test.Note("Test.IfNot.ValuesEqual<ImplementsNone>(null, null)");
            DummyTest.IfNot.ValuesEqual<ImplementsNone>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsNone(0), null)");
            DummyTest.IfNot.ValuesEqual(new ImplementsNone(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(null, new ImplementsNone(0))");
            DummyTest.IfNot.ValuesEqual(null, new ImplementsNone(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsNone(5), new ImplementsNone(0))");
            DummyTest.IfNot.ValuesEqual(new ImplementsNone(5), new ImplementsNone(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5))");
            DummyTest.IfNot.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5), new TestEqualityComparer())");
            DummyTest.IfNot.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5), new TestEqualityComparer());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(TestEqualityComparer) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");
        }

        #endregion

        #region custom equality

        [TestMethod]
        void TestValuesEqualSingle() {

            Test.Note("Test.If.ValuesEqual(1f, 1f)");
            DummyTest.If.ValuesEqual(1f, 1f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '1']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(1f, 0f)");
            DummyTest.If.ValuesEqual(1f, 0f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(1e-12f, 1.1e-12f)");
            DummyTest.If.ValuesEqual(1e-12f, 1.1e-12f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-12'; Right = '1.1E-12']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(1e-11f, 1.1e-11f)");
            DummyTest.If.ValuesEqual(1e-11f, 1.1e-11f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(1e-11f, 1.1e-11f, 1e-11f)");
            DummyTest.If.ValuesEqual(1e-11f, 1.1e-11f, 1e-11f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualSingle() {

            Test.Note("Test.IfNot.ValuesEqual(1f, 1f)");
            DummyTest.IfNot.ValuesEqual(1f, 1f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '1']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(1f, 0f)");
            DummyTest.IfNot.ValuesEqual(1f, 0f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(1e-12f, 1.1e-12f)");
            DummyTest.IfNot.ValuesEqual(1e-12f, 1.1e-12f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-12'; Right = '1.1E-12']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(1e-11f, 1.1e-11f)");
            DummyTest.IfNot.ValuesEqual(1e-11f, 1.1e-11f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(1e-11f, 1.1e-11f, 1e-11f)");
            DummyTest.IfNot.ValuesEqual(1e-11f, 1.1e-11f, 1e-11f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

        }

        [TestMethod]
        void TestValuesEqualDouble() {

            Test.Note("Test.If.ValuesEqual(1d, 1d)");
            DummyTest.If.ValuesEqual(1d, 1d);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '1']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(1d, 0d)");
            DummyTest.If.ValuesEqual(1d, 0d);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(1e-12, 1.1e-12)");
            DummyTest.If.ValuesEqual(1e-12, 1.1e-12);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-12'; Right = '1.1E-12']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(1e-11, 1.1e-11)");
            DummyTest.If.ValuesEqual(1e-11, 1.1e-11);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            Test.Note("Test.If.ValuesEqual(1e-11, 1.1e-11, 1e-11)");
            DummyTest.If.ValuesEqual(1e-11, 1.1e-11, 1e-11);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualDouble() {

            Test.Note("Test.IfNot.ValuesEqual(1d, 1d)");
            DummyTest.IfNot.ValuesEqual(1d, 1d);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '1']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(1d, 0d)");
            DummyTest.IfNot.ValuesEqual(1d, 0d);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(1e-12, 1.1e-12)");
            DummyTest.IfNot.ValuesEqual(1e-12, 1.1e-12);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-12'; Right = '1.1E-12']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(1e-11, 1.1e-11)");
            DummyTest.IfNot.ValuesEqual(1e-11, 1.1e-11);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            Test.Note("Test.IfNot.ValuesEqual(1e-11, 1.1e-11, 1e-11)");
            DummyTest.IfNot.ValuesEqual(1e-11, 1.1e-11, 1e-11);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

        }

        #endregion

        #region string null

        [TestMethod]
        void TestStringIsNullOrEmpty() {

            Test.Note("Test.If.StringIsNullOrEmpty(null)");
            DummyTest.If.StringIsNullOrEmpty(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrEmpty");

            Test.Note("Test.If.StringIsNullOrEmpty(String.Empty)");
            DummyTest.If.StringIsNullOrEmpty(String.Empty);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = '']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrEmpty");

            Test.Note("Test.If.StringIsNullOrEmpty(\" \")");
            DummyTest.If.StringIsNullOrEmpty(" ");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ' ']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrEmpty");

            Test.Note("Test.If.StringIsNullOrEmpty(\"content\")");
            DummyTest.If.StringIsNullOrEmpty("content");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'content']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrEmpty");

        }

        [TestMethod]
        void TestNotStringIsNullOrEmpty() {

            Test.Note("Test.IfNot.StringIsNullOrEmpty(null)");
            DummyTest.IfNot.StringIsNullOrEmpty(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrEmpty");

            Test.Note("Test.IfNot.StringIsNullOrEmpty(String.Empty)");
            DummyTest.IfNot.StringIsNullOrEmpty(String.Empty);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = '']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrEmpty");

            Test.Note("Test.IfNot.StringIsNullOrEmpty(\" \")");
            DummyTest.IfNot.StringIsNullOrEmpty(" ");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ' ']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrEmpty");

            Test.Note("Test.IfNot.StringIsNullOrEmpty(\"content\")");
            DummyTest.IfNot.StringIsNullOrEmpty("content");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'content']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrEmpty");
        }

        [TestMethod]
        void TestStringNullWhiteSpace() {

            Test.Note("Test.If.StringIsNullOrWhiteSpace(null)");
            DummyTest.If.StringIsNullOrWhiteSpace(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrWhiteSpace");

            Test.Note("Test.If.StringIsNullOrWhiteSpace(String.Empty)");
            DummyTest.If.StringIsNullOrWhiteSpace(String.Empty);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = '']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrWhiteSpace");

            Test.Note("Test.If.StringIsNullOrWhiteSpace(\" \")");
            DummyTest.If.StringIsNullOrWhiteSpace(" ");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ' ']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrWhiteSpace");

            Test.Note("Test.If.StringIsNullOrWhiteSpace(\"content\")");
            DummyTest.If.StringIsNullOrWhiteSpace("content");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'content']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrWhiteSpace");
        }

        [TestMethod]
        void TestNotStringNullWhiteSpace() {

            Test.Note("Test.IfNot.StringIsNullOrWhiteSpace(null)");
            DummyTest.IfNot.StringIsNullOrWhiteSpace(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrWhiteSpace");

            Test.Note("Test.IfNot.StringIsNullOrWhiteSpace(String.Empty)");
            DummyTest.IfNot.StringIsNullOrWhiteSpace(String.Empty);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = '']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrWhiteSpace");

            Test.Note("Test.IfNot.StringIsNullOrWhiteSpace(\" \")");
            DummyTest.IfNot.StringIsNullOrWhiteSpace(" ");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ' ']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrWhiteSpace");

            Test.Note("Test.IfNot.StringIsNullOrWhiteSpace(\"content\")");
            DummyTest.IfNot.StringIsNullOrWhiteSpace("content");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'content']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrWhiteSpace");
        }

        #endregion

        #region string start/end

        [TestMethod]
        void TestStringStartsWithChar() {

            Test.Note("Test.If.StringStartsWith(null, 'x')");
            DummyTest.If.StringStartsWith(null, 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            Test.Note("Test.If.StringStartsWith(\"\", 'x')");
            DummyTest.If.StringStartsWith("", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            Test.Note("Test.If.StringStartsWith(\"ax\", 'x')");
            DummyTest.If.StringStartsWith("ax", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'ax'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            Test.Note("Test.If.StringStartsWith(\"xa\", 'x')");
            DummyTest.If.StringStartsWith("xa", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xa'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");
        }

        [TestMethod]
        void TestNotStringStartsWithChar() {

            Test.Note("Test.IfNot.StringStartsWith(null, 'x')");
            DummyTest.IfNot.StringStartsWith(null, 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            Test.Note("Test.IfNot.StringStartsWith(\"\", 'x')");
            DummyTest.IfNot.StringStartsWith("", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            Test.Note("Test.IfNot.StringStartsWith(\"ax\", 'x')");
            DummyTest.IfNot.StringStartsWith("ax", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'ax'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            Test.Note("Test.IfNot.StringStartsWith(\"xa\", 'x')");
            DummyTest.IfNot.StringStartsWith("xa", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xa'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

        }

        [TestMethod]
        void TestStringStartsWithString() {

            Test.Note("Test.If.StringStartsWith(null, \"xy\")");
            DummyTest.If.StringStartsWith(null, "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            Test.Note("Test.If.StringStartsWith(\"\", \"xy\")");
            DummyTest.If.StringStartsWith("", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            Test.Note("Test.If.StringStartsWith(\"axy\", null)");
            DummyTest.If.StringStartsWith("axy", null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            Test.Note("Test.If.StringStartsWith(\"axy\", \"xy\")");
            DummyTest.If.StringStartsWith("axy", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            Test.Note("Test.If.StringStartsWith(\"xya\", \"xy\")");
            DummyTest.If.StringStartsWith("xya", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

        }

        [TestMethod]
        void TestNotStringStartsWithString() {

            Test.Note("Test.IfNot.StringStartsWith(null, \"xy\")");
            DummyTest.IfNot.StringStartsWith(null, "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            Test.Note("Test.IfNot.StringStartsWith(\"\", \"xy\")");
            DummyTest.IfNot.StringStartsWith("", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            Test.Note("Test.IfNot.StringStartsWith(\"axy\", null)");
            DummyTest.IfNot.StringStartsWith("axy", null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            Test.Note("Test.IfNot.StringStartsWith(\"axy\", \"xy\")");
            DummyTest.IfNot.StringStartsWith("axy", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            Test.Note("Test.IfNot.StringStartsWith(\"xya\", \"xy\")");
            DummyTest.IfNot.StringStartsWith("xya", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");
        }

        [TestMethod]
        void TestStringEndsWithChar() {

            Test.Note("Test.If.StringEndsWith(null, 'x')");
            DummyTest.If.StringEndsWith(null, 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            Test.Note("Test.If.StringEndsWith(\"\", 'x')");
            DummyTest.If.StringEndsWith("", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            Test.Note("Test.If.StringEndsWith(\"xa\", 'x')");
            DummyTest.If.StringEndsWith("xa", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xa'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            Test.Note("Test.If.StringEndsWith(\"ax\", 'x')");
            DummyTest.If.StringEndsWith("ax", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'ax'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");
        }

        [TestMethod]
        void TestNotStringEndsWithChar() {

            Test.Note("Test.IfNot.StringEndsWith(null, 'x')");
            DummyTest.IfNot.StringEndsWith(null, 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            Test.Note("Test.IfNot.StringEndsWith(\"\", 'x')");
            DummyTest.IfNot.StringEndsWith("", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            Test.Note("Test.IfNot.StringEndsWith(\"xa\", 'x')");
            DummyTest.IfNot.StringEndsWith("xa", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xa'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            Test.Note("Test.IfNot.StringEndsWith(\"ax\", 'x')");
            DummyTest.IfNot.StringEndsWith("ax", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'ax'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

        }

        [TestMethod]
        void TestStringEndsWithString() {

            Test.Note("Test.If.StringEndsWith(null, \"xy\")");
            DummyTest.If.StringEndsWith(null, "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            Test.Note("Test.If.StringEndsWith(\"\", \"xy\")");
            DummyTest.If.StringEndsWith("", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            Test.Note("Test.If.StringEndsWith(\"xya\", null)");
            DummyTest.If.StringEndsWith("xya", null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            Test.Note("Test.If.StringEndsWith(\"xya\", \"xy\")");
            DummyTest.If.StringEndsWith("xya", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            Test.Note("Test.If.StringEndsWith(\"axy\", \"xy\")");
            DummyTest.If.StringEndsWith("axy", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

        }

        [TestMethod]
        void TestNotStringEndsWithString() {

            Test.Note("Test.IfNot.StringEndsWith(null, \"xy\")");
            DummyTest.IfNot.StringEndsWith(null, "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            Test.Note("Test.IfNot.StringEndsWith(\"\", \"xy\")");
            DummyTest.IfNot.StringEndsWith("", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            Test.Note("Test.IfNot.StringEndsWith(\"xya\", null)");
            DummyTest.IfNot.StringEndsWith("xya", null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            Test.Note("Test.IfNot.StringEndsWith(\"xya\", \"xy\")");
            DummyTest.IfNot.StringEndsWith("xya", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            Test.Note("Test.IfNot.StringEndsWith(\"axy\", \"xy\")");
            DummyTest.IfNot.StringEndsWith("axy", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");
        }

        #endregion

    }
}
