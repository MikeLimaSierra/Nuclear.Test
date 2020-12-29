using System;

using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Sample {
    class PersonRenamedEventArgs_uTests {

        [TestMethod]
        void Inheritance() {

            Test.If.Type.IsSubClass<PersonRenamedEventArgs, ValueChangedEventArgs<String>>();

        }

    }
}
