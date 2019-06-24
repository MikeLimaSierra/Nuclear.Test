using System;
using System.ComponentModel;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;
using Sample;
using TestExtensions;

namespace NetStandardSampleTests {
    class MyClassTests {

        [TestMethod]
#if NETFRAMEWORK
        void TestImplementationFramework() {
#elif NETCOREAPP
        void TestImplementationCore() {
#elif NETSTANDARD
        void TestImplementationStandard() {
#endif

            Test.If.TypeImplements<MyClass, INotifyPropertyChanged>();
            Test.IfNot.TypeImplements<MyClass, IDisposable>();

        }

        [TestMethod]
#if NETFRAMEWORK
        void TestConstructorsFramework() {
#elif NETCOREAPP
        void TestConstructorsCore() {
#elif NETSTANDARD
        void TestConstructorsStandard() {
#endif

            MyClass obj = null;

            Test.If.ThrowsException(() => obj = new MyClass(null), out ArgumentNullException ex);
            Test.If.Null(obj);

            Test.IfNot.ThrowsException(() => obj = new MyClass("asdf"), out ex);
            Test.IfNot.Null(obj);
            Test.If.ValuesEqual(obj.Content, "asdf");

            Test.IfNot.ThrowsException(() => obj = new MyClass("Hello World!"), out ex);
            Test.IfNot.Null(obj);
            Test.If.ValuesEqual(obj.Content, "Hello World!");

        }

        [TestMethod]
#if NETFRAMEWORK
        void TestConstructorsAnotherWayFramework() {
#elif NETCOREAPP
        void TestConstructorsAnotherWayCore() {
#elif NETSTANDARD
        void TestConstructorsAnotherWayStandard() {
#endif

            GenericTests.TestCtorGeneric("The quick brown fox");
            GenericTests.TestCtorGeneric("jumped over the lazy dog.");

            GenericTests.TestCtorGeneric("The sun went down in the east.");
            GenericTests.TestCtorGeneric("Holy crap, this is not astronomically correct.");

        }

        [TestMethod]
#if NETFRAMEWORK
        void TestUsingTestExtensionsFramework() {
#elif NETCOREAPP
        void TestUsingTestExtensionsCore() {
#elif NETSTANDARD
        void TestUsingTestExtensionsStandard() {
#endif

            Test.If.IsHelloWorld("Hello World!");
            Test.IfNot.IsHelloWorld("Good bye World!");

        }

        [TestMethod]
#if NETFRAMEWORK
        void TestContentPropertyFramework() {
#elif NETCOREAPP
        void TestContentPropertyCore() {
#elif NETSTANDARD
        void TestContentPropertyStandard() {
#endif

            MyClass obj = new MyClass("asdf");

            Test.IfNot.ThrowsException(() => obj.Content = "new content", out Exception ex);
            Test.If.Null(ex);
            Test.If.ValuesEqual(obj.Content, "new content");

        }

        [TestMethod]
#if NETFRAMEWORK
        void TestPropertyChangedFramework() {
#elif NETCOREAPP
        void TestPropertyChangedCore() {
#elif NETSTANDARD
        void TestPropertyChangedStandard() {
#endif

            MyClass obj = new MyClass("asdf");

            Test.If.RaisesPropertyChangedEvent(obj, () => obj.Content = "new content", out Object sender, out PropertyChangedEventArgs e);
            Test.If.ReferencesEqual(obj, sender);
            Test.If.ValuesEqual(e.PropertyName, "Content");

        }

    }
}
