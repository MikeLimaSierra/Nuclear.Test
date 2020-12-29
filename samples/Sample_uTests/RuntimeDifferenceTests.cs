using System;
using System.Xml.Linq;

using Nuclear.TestSite;

namespace SampleTests {
    class RuntimeDifferenceTests {

        [TestMethod(ignoreReason: "Is going to fail on one platform or another.")]
        void TestCoreStyle() {

            DateTime someDate = new DateTime(2042, 3, 14, 8, 35, 57, 128);
            XAttribute xAttr = null;

            Test.Note("XAttribute(XName, Object) => XContainer.GetStringValue(Object)");
            Test.IfNot.Action.ThrowsException(() => xAttr = new XAttribute(XName.Get("myAttribute"), someDate), out Exception ex);
            Test.IfNot.Object.IsNull(xAttr);
            Test.If.Value.IsEqual(xAttr.Name, "myAttribute");

            Test.Note(".NETCore uses ToString(\"o\")");
            // actually this is .NETCore 2.0 only.
            // .NETCore 2.1+ uses the .NETFramework style below.
            Test.Note("String will be '2042-03-14T08:35:57.1280000'");
            Test.If.Value.IsEqual(xAttr.Value, "2042-03-14T08:35:57.1280000");

        }

        [TestMethod(ignoreReason: "Is going to fail on one platform or another.")]
        void TestFrameworkStyle() {

            DateTime someDate = new DateTime(2042, 3, 14, 8, 35, 57, 128);
            XAttribute xAttr = null;

            Test.Note("XAttribute(XName, Object) => XContainer.GetStringValue(Object)");
            Test.IfNot.Action.ThrowsException(() => xAttr = new XAttribute(XName.Get("myAttribute"), someDate), out Exception ex);
            Test.IfNot.Object.IsNull(xAttr);
            Test.If.Value.IsEqual(xAttr.Name, "myAttribute");

            Test.Note(".NETFramework uses 'yyyy-MM-dd' + 'T' + 'HH:mm:ss.#######'");
            Test.Note("String will be '2042-03-14T08:35:57.128'");
            Test.If.Value.IsEqual(xAttr.Value, "2042-03-14T08:35:57.128");

        }

    }
}
