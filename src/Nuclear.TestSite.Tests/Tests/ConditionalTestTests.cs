using System;
using System.ComponentModel;
using Ntt;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Tests {
    class ConditionalTestTests {

        #region references

        [TestMethod]
        void TestNull() {
            DummyTest.If.Null(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Object: null]");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.Null");

            DummyTest.If.Null(new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Object: not null]");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.Null");

        }

        [TestMethod]
        void TestNotNull() {

            DummyTest.IfNot.Null(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Object: null]");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.Null");

            DummyTest.IfNot.Null(new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Object: not null]");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.Null");

        }

        [TestMethod]
        void TestReferencesEqual() {

            DummyTest.If.ReferencesEqual(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

            DummyTest.If.ReferencesEqual(new Object(), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

            DummyTest.If.ReferencesEqual(null, new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

            DummyTest.If.ReferencesEqual(new Object(), new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

            DummyTest.If.ReferencesEqual(DummyTestResults.Instance, DummyTestResults.Instance);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ReferencesEqual");

        }

        [TestMethod]
        void TestNotReferencesEqual() {

            DummyTest.IfNot.ReferencesEqual(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

            DummyTest.IfNot.ReferencesEqual(new Object(), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

            DummyTest.IfNot.ReferencesEqual(null, new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

            DummyTest.IfNot.ReferencesEqual(new Object(), new Object());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "References don't equal.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ReferencesEqual");

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

            DummyTest.If.ThrowsException(() => throw new Exception("test message"), out Exception ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.Exception");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            DummyTest.If.ThrowsException(() => throw new ArgumentException("test message"), out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.ArgumentException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            DummyTest.If.ThrowsException(() => { }, out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.If.Null(ex);

        }

        [TestMethod]
        void TestNotThrowsException() {

            DummyTest.IfNot.ThrowsException(() => throw new Exception("test message"), out Exception ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.Exception");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            DummyTest.IfNot.ThrowsException(() => throw new ArgumentException("test message"), out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.ArgumentException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            DummyTest.IfNot.ThrowsException(() => { }, out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.If.Null(ex);

        }

        [TestMethod]
        void TestThrowsExceptionGeneric() {

            DummyTest.If.ThrowsException(() => throw new SystemException("test message"), out SystemException ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.SystemException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            DummyTest.If.ThrowsException(() => throw new ArgumentException("test message"), out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.ArgumentException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            DummyTest.If.ThrowsException(() => throw new ArgumentException("test message"), out NullReferenceException ex_);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.If.Null(ex_);

            DummyTest.If.ThrowsException(() => { }, out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ThrowsException");
            Test.If.Null(ex);

        }

        [TestMethod]
        void TestNotThrowsExceptionGeneric() {

            DummyTest.IfNot.ThrowsException(() => throw new SystemException("test message"), out SystemException ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.SystemException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            DummyTest.IfNot.ThrowsException(() => throw new ArgumentException("test message"), out ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'System.ArgumentException");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.Message, "test message");

            DummyTest.IfNot.ThrowsException(() => throw new ArgumentException("test message"), out NullReferenceException ex_);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Exception = 'null");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ThrowsException");
            Test.If.Null(ex_);

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

            DummyTest.If.OfType<ClassZero>(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'null'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

            DummyTest.If.OfType<ClassZero>(new ClassZero());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassZero'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

            DummyTest.If.OfType<ClassZero>(new ClassOne());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassOne'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

            DummyTest.If.OfType<ClassZero>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

            DummyTest.If.OfType<IInterfaceOne>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfType");

        }

        [TestMethod]
        void TestNotOfType() {

            DummyTest.IfNot.OfType<ClassZero>(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'null'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");

            DummyTest.IfNot.OfType<ClassZero>(new ClassZero());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassZero'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");

            DummyTest.IfNot.OfType<ClassZero>(new ClassOne());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassOne'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");

            DummyTest.IfNot.OfType<ClassZero>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");

            DummyTest.IfNot.OfType<IInterfaceOne>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfType");
        }

        [TestMethod]
        void TestOfExactType() {

            DummyTest.If.OfExactType<ClassZero>(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'null'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfExactType");

            DummyTest.If.OfExactType<ClassZero>(new ClassZero());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassZero'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfExactType");

            DummyTest.If.OfExactType<ClassZero>(new ClassOne());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassOne'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfExactType");

            DummyTest.If.OfExactType<ClassZero>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.OfExactType");
        }

        [TestMethod]
        void TestNotOfExactType() {

            DummyTest.IfNot.OfExactType<ClassZero>(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'null'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfExactType");

            DummyTest.IfNot.OfExactType<ClassZero>(new ClassZero());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassZero'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfExactType");

            DummyTest.IfNot.OfExactType<ClassZero>(new ClassOne());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassOne'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfExactType");

            DummyTest.IfNot.OfExactType<ClassZero>(new ClassTwo());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is 'Ntt.ClassTwo'. Given type is 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.OfExactType");
        }

        [TestMethod]
        void TestTypeImplements() {

            DummyTest.If.TypeImplements<ClassZero, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' is not an interface.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            DummyTest.If.TypeImplements<ClassTwo, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassTwo' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            DummyTest.If.TypeImplements<ClassTwo, IInterfaceTwo>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassTwo' doesn't implement interface 'Ntt.IInterfaceTwo'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            DummyTest.If.TypeImplements<ClassZero, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            DummyTest.If.TypeImplements<IInterfaceTwo, IInterfaceTwo>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceTwo' doesn't implement interface 'Ntt.IInterfaceTwo'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");

            DummyTest.If.TypeImplements<IInterfaceTwo, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceTwo' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeImplements");
        }

        [TestMethod]
        void TestNotTypeImplements() {

            DummyTest.IfNot.TypeImplements<ClassZero, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' is not an interface.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            DummyTest.IfNot.TypeImplements<ClassTwo, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassTwo' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            DummyTest.IfNot.TypeImplements<ClassTwo, IInterfaceTwo>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassTwo' doesn't implement interface 'Ntt.IInterfaceTwo'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            DummyTest.IfNot.TypeImplements<ClassZero, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            DummyTest.IfNot.TypeImplements<IInterfaceTwo, IInterfaceTwo>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceTwo' doesn't implement interface 'Ntt.IInterfaceTwo'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

            DummyTest.IfNot.TypeImplements<IInterfaceTwo, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceTwo' implements interface 'Ntt.IInterfaceOne'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeImplements");

        }

        [TestMethod]
        void TestTypeIsSubclass() {

            DummyTest.If.TypeIsSubClass<ClassZero, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' is no subclass of 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeIsSubClass");

            DummyTest.If.TypeIsSubClass<ClassOne, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassOne' is subclass of 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeIsSubClass");

            DummyTest.If.TypeIsSubClass<ClassOne, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceOne' is not a class.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeIsSubClass");

            DummyTest.If.TypeIsSubClass<IInterfaceOne, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceOne' is not a class.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.TypeIsSubClass");

        }

        [TestMethod]
        void TestNotTypeIsSubclass() {

            DummyTest.IfNot.TypeIsSubClass<ClassZero, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassZero' is no subclass of 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeIsSubClass");

            DummyTest.IfNot.TypeIsSubClass<ClassOne, ClassZero>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.ClassOne' is subclass of 'Ntt.ClassZero'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeIsSubClass");

            DummyTest.IfNot.TypeIsSubClass<ClassOne, IInterfaceOne>();
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Type 'Ntt.IInterfaceOne' is not a class.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.TypeIsSubClass");

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

            DummyTest.If.RaisesPropertyChangedEvent(null, () => { }, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is null.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesPropertyChangedEvent");

            DummyTest.If.RaisesPropertyChangedEvent(pccObject, () => throw new Exception(), out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Action threw Exception: Exception of type 'System.Exception' was thrown");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesPropertyChangedEvent");

            DummyTest.If.RaisesPropertyChangedEvent(pccObject, () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesPropertyChangedEvent");

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

            DummyTest.IfNot.RaisesPropertyChangedEvent(null, () => { }, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is null.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesPropertyChangedEvent");

            DummyTest.IfNot.RaisesPropertyChangedEvent(pccObject, () => throw new Exception(), out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Action threw Exception: Exception of type 'System.Exception' was thrown");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesPropertyChangedEvent");

            DummyTest.IfNot.RaisesPropertyChangedEvent(pccObject, () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesPropertyChangedEvent");

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

            DummyTest.If.RaisesEvent(null, "PropertyChanged", () => { }, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is null.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged", () => throw new Exception(), out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Action threw Exception: Exception of type 'System.Exception' was thrown");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged", () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged_", () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Event with name 'PropertyChanged_' could not be found.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

            DummyTest.If.RaisesEvent(pccObject, "PropertyChanged", () => { }, out sender, out DoWorkEventArgs e_);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Given type of arguments 'System.ComponentModel.DoWorkEventArgs' doesn't match event handler of type 'System.ComponentModel.PropertyChangedEventHandler'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.RaisesEvent");

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

            DummyTest.IfNot.RaisesEvent(null, "PropertyChanged", () => { }, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Object is null.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged", () => throw new Exception(), out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.StringStartsWith(Statics.GetLastResult(DummyTestResults.Instance).Message, "Action threw Exception: Exception of type 'System.Exception' was thrown");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged", () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' thrown.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged_", () => { }, out sender, out e);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Event with name 'PropertyChanged_' could not be found.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

            DummyTest.IfNot.RaisesEvent(pccObject, "PropertyChanged", () => { }, out sender, out DoWorkEventArgs e_);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "Given type of arguments 'System.ComponentModel.DoWorkEventArgs' doesn't match event handler of type 'System.ComponentModel.PropertyChangedEventHandler'.");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.RaisesEvent");

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

            DummyTest.If.True(true);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'True']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.True");

            DummyTest.If.True(false);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'False']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.True");

            DummyTest.If.True(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.True");

        }

        [TestMethod]
        void TestNotTrue() {

            DummyTest.IfNot.True(true);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'True']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.True");

            DummyTest.IfNot.True(false);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'False']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.True");

            DummyTest.IfNot.True(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.True");

        }

        [TestMethod]
        void TestFalse() {

            DummyTest.If.False(true);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'True']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.False");

            DummyTest.If.False(false);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'False']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.False");

            DummyTest.If.False(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.False");

        }

        [TestMethod]
        void TestNotFalse() {

            DummyTest.IfNot.False(true);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'True']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.False");

            DummyTest.IfNot.False(false);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Value = 'False']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.False");

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

            DummyTest.If.ValuesEqual<ImplementsIEquatableT>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIEquatableT(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(GenericEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(null, new ImplementsIEquatableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(GenericEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIEquatableT.IEquatable<T>) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIEquatableT.IEquatable<T>) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualIEquatableT() {

            DummyTest.IfNot.ValuesEqual<ImplementsIEquatableT>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIEquatableT(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(GenericEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(null, new ImplementsIEquatableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(GenericEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIEquatableT.IEquatable<T>) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIEquatableT(5), new ImplementsIEquatableT(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIEquatableT.IEquatable<T>) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");
        }

        [TestMethod]
        void TestValuesEqualIComparableT() {

            DummyTest.If.ValuesEqual<ImplementsIComparableT>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIComparableT(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(null, new ImplementsIComparableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparableT.IComparable<T>) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparableT.IComparable<T>) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualIComparableT() {

            DummyTest.IfNot.ValuesEqual<ImplementsIComparableT>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIComparableT(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(null, new ImplementsIComparableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparableT.IComparable<T>) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIComparableT(5), new ImplementsIComparableT(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparableT.IComparable<T>) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");
        }

        [TestMethod]
        void TestValuesEqualIComparable() {

            DummyTest.If.ValuesEqual<ImplementsIComparable>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIComparable(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(null, new ImplementsIComparable(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparable.IComparable) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparable.IComparable) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualIComparable() {

            DummyTest.IfNot.ValuesEqual<ImplementsIComparable>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIComparable(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(null, new ImplementsIComparable(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparable.IComparable) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsIComparable(5), new ImplementsIComparable(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(Ntt.ImplementsIComparable.IComparable) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");
        }

        [TestMethod]
        void TestValuesEqualEqualityComparerT() {

            DummyTest.If.ValuesEqual<ImplementsNone>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsNone(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(null, new ImplementsNone(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5), new TestEqualityComparer());
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 6);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(TestEqualityComparer) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualEqualityComparerT() {

            DummyTest.IfNot.ValuesEqual<ImplementsNone>(null, null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = 'null'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsNone(0), null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '0'; Right = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(null, new ImplementsNone(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = 'null'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsNone(5), new ImplementsNone(0));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '5'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(new ImplementsNone(5), new ImplementsNone(5));
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "(ObjectEqualityComparer`1) [Left = '5'; Right = '5']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

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

            DummyTest.If.ValuesEqual(1f, 1f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '1']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(1f, 0f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(1e-12f, 1.1e-12f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-12'; Right = '1.1E-12']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(1e-11f, 1.1e-11f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(1e-11f, 1.1e-11f, 1e-11f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualSingle() {

            DummyTest.IfNot.ValuesEqual(1f, 1f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '1']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(1f, 0f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(1e-12f, 1.1e-12f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-12'; Right = '1.1E-12']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(1e-11f, 1.1e-11f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(1e-11f, 1.1e-11f, 1e-11f);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

        }

        [TestMethod]
        void TestValuesEqualDouble() {

            DummyTest.If.ValuesEqual(1d, 1d);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '1']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(1d, 0d);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(1e-12, 1.1e-12);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-12'; Right = '1.1E-12']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(1e-11, 1.1e-11);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

            DummyTest.If.ValuesEqual(1e-11, 1.1e-11, 1e-11);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.ValuesEqual");

        }

        [TestMethod]
        void TestNotValuesEqualDouble() {

            DummyTest.IfNot.ValuesEqual(1d, 1d);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '1']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(1d, 0d);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1'; Right = '0']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(1e-12, 1.1e-12);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-12'; Right = '1.1E-12']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

            DummyTest.IfNot.ValuesEqual(1e-11, 1.1e-11);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[Left = '1E-11'; Right = '1.1E-11']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.ValuesEqual");

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

            DummyTest.If.StringIsNullOrEmpty(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrEmpty");

            DummyTest.If.StringIsNullOrEmpty(String.Empty);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = '']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrEmpty");

            DummyTest.If.StringIsNullOrEmpty(" ");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ' ']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrEmpty");

            DummyTest.If.StringIsNullOrEmpty("content");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'content']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrEmpty");

        }

        [TestMethod]
        void TestNotStringIsNullOrEmpty() {

            DummyTest.IfNot.StringIsNullOrEmpty(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrEmpty");

            DummyTest.IfNot.StringIsNullOrEmpty(String.Empty);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = '']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrEmpty");

            DummyTest.IfNot.StringIsNullOrEmpty(" ");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ' ']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrEmpty");

            DummyTest.IfNot.StringIsNullOrEmpty("content");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'content']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrEmpty");
        }

        [TestMethod]
        void TestStringNullWhiteSpace() {

            DummyTest.If.StringIsNullOrWhiteSpace(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrWhiteSpace");

            DummyTest.If.StringIsNullOrWhiteSpace(String.Empty);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = '']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrWhiteSpace");

            DummyTest.If.StringIsNullOrWhiteSpace(" ");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ' ']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrWhiteSpace");

            DummyTest.If.StringIsNullOrWhiteSpace("content");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'content']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringIsNullOrWhiteSpace");
        }

        [TestMethod]
        void TestNotStringNullWhiteSpace() {

            DummyTest.IfNot.StringIsNullOrWhiteSpace(null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrWhiteSpace");

            DummyTest.IfNot.StringIsNullOrWhiteSpace(String.Empty);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = '']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrWhiteSpace");

            DummyTest.IfNot.StringIsNullOrWhiteSpace(" ");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ' ']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringIsNullOrWhiteSpace");

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

            DummyTest.If.StringStartsWith(null, 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            DummyTest.If.StringStartsWith("", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            DummyTest.If.StringStartsWith("ax", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'ax'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            DummyTest.If.StringStartsWith("xa", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xa'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");
        }

        [TestMethod]
        void TestNotStringStartsWithChar() {

            DummyTest.IfNot.StringStartsWith(null, 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            DummyTest.IfNot.StringStartsWith("", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            DummyTest.IfNot.StringStartsWith("ax", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'ax'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            DummyTest.IfNot.StringStartsWith("xa", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xa'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

        }

        [TestMethod]
        void TestStringStartsWithString() {

            DummyTest.If.StringStartsWith(null, "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            DummyTest.If.StringStartsWith("", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            DummyTest.If.StringStartsWith("axy", null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            DummyTest.If.StringStartsWith("axy", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

            DummyTest.If.StringStartsWith("xya", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringStartsWith");

        }

        [TestMethod]
        void TestNotStringStartsWithString() {

            DummyTest.IfNot.StringStartsWith(null, "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            DummyTest.IfNot.StringStartsWith("", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            DummyTest.IfNot.StringStartsWith("axy", null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            DummyTest.IfNot.StringStartsWith("axy", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");

            DummyTest.IfNot.StringStartsWith("xya", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringStartsWith");
        }

        [TestMethod]
        void TestStringEndsWithChar() {

            DummyTest.If.StringEndsWith(null, 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            DummyTest.If.StringEndsWith("", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            DummyTest.If.StringEndsWith("xa", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xa'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            DummyTest.If.StringEndsWith("ax", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'ax'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");
        }

        [TestMethod]
        void TestNotStringEndsWithChar() {

            DummyTest.IfNot.StringEndsWith(null, 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            DummyTest.IfNot.StringEndsWith("", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            DummyTest.IfNot.StringEndsWith("xa", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xa'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            DummyTest.IfNot.StringEndsWith("ax", 'x');
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'ax'; Value = 'x']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

        }

        [TestMethod]
        void TestStringEndsWithString() {

            DummyTest.If.StringEndsWith(null, "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            DummyTest.If.StringEndsWith("", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            DummyTest.If.StringEndsWith("xya", null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            DummyTest.If.StringEndsWith("xya", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

            DummyTest.If.StringEndsWith("axy", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.If.StringEndsWith");

        }

        [TestMethod]
        void TestNotStringEndsWithString() {

            DummyTest.IfNot.StringEndsWith(null, "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'null'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            DummyTest.IfNot.StringEndsWith("", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 2);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = ''; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            DummyTest.IfNot.StringEndsWith("xya", null);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 3);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'null']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            DummyTest.IfNot.StringEndsWith("xya", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 4);
            Test.If.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'xya'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");

            DummyTest.IfNot.StringEndsWith("axy", "xy");
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 5);
            Test.IfNot.True(Statics.GetLastResult(DummyTestResults.Instance).Result);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "[String = 'axy'; Value = 'xy']");
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).TestInstruction, "Test.IfNot.StringEndsWith");
        }

        #endregion

    }
}
