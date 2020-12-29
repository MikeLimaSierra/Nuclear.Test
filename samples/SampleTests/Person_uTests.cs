using System;
using System.ComponentModel;

using Nuclear.TestSite;

namespace Sample {
    class Person_uTests {

        #region ctors

        [TestMethod]
        [TestParameters(null, null)]
        [TestParameters(null, "")]
        [TestParameters("", null)]
        [TestParameters("", "")]
        [TestParameters("", " ")]
        [TestParameters(" ", "")]
        [TestParameters(" ", " ")]
        [TestParameters(" ", "Asdf")]
        [TestParameters("Asdf", " ")]
        void CtorThrows(String firstName, String lastName) {

            Test.If.Action.ThrowsException(() => new Person(firstName, lastName), out Exception ex);

        }

        [TestMethod]
        [TestParameters("John", "Doe")]
        [TestParameters("Jane", "Doe")]
        void Ctor(String firstName, String lastName) {

            Test.IfNot.Action.ThrowsException(() => new Person(firstName, lastName), out Exception ex);

        }

        #endregion

        #region FirstName

        [TestMethod]
        [TestParameters("John", "Doe", null)]
        [TestParameters("John", "Doe", "")]
        [TestParameters("John", "Doe", " ")]
        void FirstNameThrows(String firstName, String lastName, String @value) {

            Person p = new Person(firstName, lastName);

            Test.If.Action.ThrowsException(() => p.FirstName = @value, out Exception ex);

        }

        [TestMethod]
        [TestParameters("John", "Doe", "Mikey", "Mikey Doe")]
        [TestParameters("John", "Doe", "Mitch", "Mitch Doe")]
        void FirstName(String firstName, String lastName, String @value, String expectedFullName) {

            Person p = new Person(firstName, lastName);

            Test.If.Action.RaisesPropertyChangedEvent(() => p.FirstName = @value, p, out EventData<PropertyChangedEventArgs> eventData);
            Test.If.Value.IsEqual(eventData.Sender, p);
            Test.If.Value.IsEqual(eventData.EventArgs.PropertyName, nameof(Person.FirstName));
            Test.If.Value.IsEqual(p.FirstName, @value);
            Test.If.Value.IsEqual(p.LastName, lastName);
            Test.If.Value.IsEqual(p.FullName, expectedFullName);

        }

        [TestMethod]
        [TestParameters("John", "Doe", "Mikey", "Mikey Doe")]
        [TestParameters("John", "Doe", "Mitch", "Mitch Doe")]
        void FirstNameRenames(String firstName, String lastName, String @value, String expectedFullName) {

            Person p = new Person(firstName, lastName);
            String old = p.FullName;

            Test.If.Action.RaisesEvent(() => p.FirstName = @value, p, "Renamed", out EventData<PersonRenamedEventArgs> eventData);
            Test.If.Value.IsEqual(eventData.Sender, p);
            Test.If.Value.IsEqual(eventData.EventArgs.Old, old);
            Test.If.Value.IsEqual(eventData.EventArgs.New, expectedFullName);
            Test.If.Value.IsEqual(p.FirstName, @value);
            Test.If.Value.IsEqual(p.LastName, lastName);
            Test.If.Value.IsEqual(p.FullName, expectedFullName);

        }

        #endregion

        #region LastName

        [TestMethod]
        [TestParameters("John", "Doe", null)]
        [TestParameters("John", "Doe", "")]
        [TestParameters("John", "Doe", " ")]
        void LastNameThrows(String firstName, String lastName, String @value) {

            Person p = new Person(firstName, lastName);

            Test.If.Action.ThrowsException(() => p.LastName = @value, out Exception ex);

        }

        [TestMethod]
        [TestParameters("John", "Doe", "Dork", "John Dork")]
        [TestParameters("John", "Doe", "Drum", "John Drum")]
        void LastName(String firstName, String lastName, String @value, String expectedFullName) {

            Person p = new Person(firstName, lastName);

            Test.If.Action.RaisesPropertyChangedEvent(() => p.LastName = @value, p, out EventData<PropertyChangedEventArgs> eventData);
            Test.If.Value.IsEqual(eventData.Sender, p);
            Test.If.Value.IsEqual(eventData.EventArgs.PropertyName, nameof(Person.LastName));
            Test.If.Value.IsEqual(p.FirstName, firstName);
            Test.If.Value.IsEqual(p.LastName, @value);
            Test.If.Value.IsEqual(p.FullName, expectedFullName);

        }

        [TestMethod]
        [TestParameters("John", "Doe", "Dork", "John Dork")]
        [TestParameters("John", "Doe", "Drum", "John Drum")]
        void LastNameRenames(String firstName, String lastName, String @value, String expectedFullName) {

            Person p = new Person(firstName, lastName);
            String old = p.FullName;

            Test.If.Action.RaisesEvent(() => p.LastName = @value, p, "Renamed", out EventData<PersonRenamedEventArgs> eventData);
            Test.If.Value.IsEqual(eventData.Sender, p);
            Test.If.Value.IsEqual(eventData.EventArgs.Old, old);
            Test.If.Value.IsEqual(eventData.EventArgs.New, expectedFullName);
            Test.If.Value.IsEqual(p.FirstName, firstName);
            Test.If.Value.IsEqual(p.LastName, @value);
            Test.If.Value.IsEqual(p.FullName, expectedFullName);

        }

        #endregion

        #region FullName

        [TestMethod]
        [TestParameters("John", "Doe", "John Doe")]
        [TestParameters("Jane", "Doe", "Jane Doe")]
        void FullName(String firstName, String lastName, String expected) {

            Person p = new Person(firstName, lastName);
            String fullName = default;

            Test.IfNot.Action.ThrowsException(() => fullName = p.FullName, out Exception ex);
            Test.If.Value.IsEqual(fullName, expected);

        }

        #endregion

    }
}
