﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class ActionTestSuit_uTests {

        #region ThrowsException

        [TestMethod]
        void ThrowsException() {

            DDTThrowsException<SystemException>((null, null),
                (1, false, "Parameter 'action' is null.", false, ""));
            DDTThrowsException<Exception>((new Action(() => { }), "() => { }"),
                (2, false, "[Exception = null]", false, ""));
            DDTThrowsException<SystemException>((new Action(() => { throw new ArgumentException("test message"); }), "() => { throw new ArgumentException(\"test message\"); }"),
                (3, true, "[Exception = 'System.ArgumentException", true, "test message"));
            DDTThrowsException<NullReferenceException>((new Action(() => { throw new ArgumentException("test message"); }), "() => { throw new ArgumentException(\"test message\"); }"),
                (4, false, "[Exception = null]", false, ""));
            DDTThrowsException<Exception>((new Action(() => { throw new Exception("test message"); }), "() => { throw new Exception(\"test message\"); }"),
                (5, true, "[Exception = 'System.Exception", true, "test message"));
            DDTThrowsException<SystemException>((new Action(() => { throw new Exception("test message"); }), "() => { throw new Exception(\"test message\"); }"),
                (6, false, "[Exception = null]", false, ""));

        }

        void DDTThrowsException<TException>((Action action, String actionString) input,
            (Int32 count, Boolean result, String message, Boolean exceptionThrown, String exMessage) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TException : Exception {

            TException ex = null;

            Test.Note($"Test.If.Action.ThrowsException({input.actionString.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Action.ThrowsException(input.action, out ex, _file, _method),
                (expected.count, expected.result, expected.message), "Test.If.Action.ThrowsException", _file, _method);

            if(expected.exceptionThrown) {
                Test.IfNot.Object.IsNull(ex, _file, _method);
                Test.If.String.StartsWith(ex.Message, expected.exMessage, _file, _method);
            }

        }

        [TestMethod]
        void NotThrowsException() {

            DDTNotThrowsException<SystemException>((null, null),
                (1, false, "Parameter 'action' is null.", false, ""));
            DDTNotThrowsException<Exception>((new Action(() => { }), "() => { }"),
                (2, true, "[Exception = null]", false, ""));
            DDTNotThrowsException<SystemException>((new Action(() => { throw new ArgumentException("test message"); }), "() => { throw new ArgumentException(\"test message\"); }"),
                (3, false, "[Exception = 'System.ArgumentException", true, "test message"));
            DDTNotThrowsException<NullReferenceException>((new Action(() => { throw new ArgumentException("test message"); }), "() => { throw new ArgumentException(\"test message\"); }"),
                (4, true, "[Exception = null]", false, ""));
            DDTNotThrowsException<Exception>((new Action(() => { throw new Exception("test message"); }), "() => { throw new Exception(\"test message\"); }"),
                (5, false, "[Exception = 'System.Exception", true, "test message"));
            DDTNotThrowsException<SystemException>((new Action(() => { throw new Exception("test message"); }), "() => { throw new Exception(\"test message\"); }"),
                (6, true, "[Exception = null]", false, ""));

        }

        void DDTNotThrowsException<TException>((Action action, String actionString) input,
            (Int32 count, Boolean result, String message, Boolean exceptionThrown, String exMessage) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TException : Exception {

            TException ex = null;

            Test.Note($"Test.IfNot.Action.ThrowsException({input.actionString.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Action.ThrowsException(input.action, out ex, _file, _method),
                (expected.count, expected.result, expected.message), "Test.IfNot.Action.ThrowsException", _file, _method);

            if(expected.exceptionThrown) {
                Test.IfNot.Object.IsNull(ex, _file, _method);
                Test.If.String.StartsWith(ex.Message, expected.exMessage, _file, _method);
            }

        }

        #endregion

        #region RaisesPropertyChangedEvent

        [TestMethod]
        void RaisesPropertyChangedEvent() {

            PropertyChangedClass pccObject = new PropertyChangedClass();

            DDTRaisesPropertyChangedEvent((null, null, null),
                (1, false, "Parameter 'action' is null.", false, ""));
            DDTRaisesPropertyChangedEvent((null, pccObject, null),
                (2, false, "Parameter 'action' is null.", false, ""));
            DDTRaisesPropertyChangedEvent((new Action(() => { }), null, "() => { }"),
                (3, false, "Parameter 'object' is null.", false, ""));

            DDTRaisesPropertyChangedEvent((new Action(() => { }), pccObject, "() => { }"),
                (4, false, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' raised.", false, ""));
            DDTRaisesPropertyChangedEvent((new Action(() => { throw new Exception(); }), pccObject, "() => { throw new Exception(); }"),
                (5, false, "Action threw Exception:", false, ""));
            DDTRaisesPropertyChangedEvent((new Action(() => { pccObject.Value = !pccObject.Value; }), pccObject, "() => { pccObject.Value = !pccObject.Value; }"),
                (6, true, "Event of type 'System.ComponentModel.PropertyChangedEventHandler' raised.", true, "Value"));

        }

        void DDTRaisesPropertyChangedEvent((Action action, INotifyPropertyChanged @object, String actionString) input,
            (Int32 count, Boolean result, String message, Boolean eventRaised, String propertyName) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Object sender = null;
            PropertyChangedEventArgs e = null;

            Test.Note($"Test.If.Action.RaisesPropertyChangedEvent({input.actionString.Print()}, {input.@object.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Action.RaisesPropertyChangedEvent(input.action, input.@object, out sender, out e, _file, _method),
                (expected.count, expected.result, expected.message), "Test.If.Action.RaisesPropertyChangedEvent", _file, _method);

            if(expected.eventRaised) {
                Test.IfNot.Object.IsNull(sender, _file, _method);
                Test.If.ReferencesEqual(input.@object, sender, _file, _method);
                Test.IfNot.Object.IsNull(e, _file, _method);
                Test.If.Value.Equals(e.PropertyName, expected.propertyName, _file, _method);
            }

        }

        [TestMethod]
        void NotRaisesPropertyChangedEvent() {

            PropertyChangedClass pccObject = new PropertyChangedClass();

            DDTNotRaisesPropertyChangedEvent((null, null, null),
                (1, false, "Parameter 'action' is null.", false, ""));
            DDTNotRaisesPropertyChangedEvent((null, pccObject, null),
                (2, false, "Parameter 'action' is null.", false, ""));
            DDTNotRaisesPropertyChangedEvent((new Action(() => { }), null, "() => { }"),
                (3, false, "Parameter 'object' is null.", false, ""));

            DDTNotRaisesPropertyChangedEvent((new Action(() => { }), pccObject, "() => { }"),
                (4, true, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' raised.", false, ""));
            DDTNotRaisesPropertyChangedEvent((new Action(() => { throw new Exception(); }), pccObject, "() => { throw new Exception(); }"),
                (5, false, "Action threw Exception:", false, ""));
            DDTNotRaisesPropertyChangedEvent((new Action(() => { pccObject.Value = !pccObject.Value; }), pccObject, "() => { pccObject.Value = !pccObject.Value; }"),
                (6, false, "Event of type 'System.ComponentModel.PropertyChangedEventHandler' raised.", true, "Value"));

        }

        void DDTNotRaisesPropertyChangedEvent((Action action, INotifyPropertyChanged @object, String actionString) input,
            (Int32 count, Boolean result, String message, Boolean eventRaised, String propertyName) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Object sender = null;
            PropertyChangedEventArgs e = null;

            Test.Note($"Test.IfNot.Action.RaisesPropertyChangedEvent({input.actionString.Print()}, {input.@object.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Action.RaisesPropertyChangedEvent(input.action, input.@object, out sender, out e, _file, _method),
                (expected.count, expected.result, expected.message), "Test.IfNot.Action.RaisesPropertyChangedEvent", _file, _method);

            if(expected.eventRaised) {
                Test.IfNot.Object.IsNull(sender, _file, _method);
                Test.If.ReferencesEqual(input.@object, sender, _file, _method);
                Test.IfNot.Object.IsNull(e, _file, _method);
                Test.If.Value.Equals(e.PropertyName, expected.propertyName, _file, _method);
            }

        }

        #endregion

        #region RaisesEvent

        [TestMethod]
        void RaisesEvent() {

            PropertyChangedClass pccObject = new PropertyChangedClass();

            DDTRaisesEvent<PropertyChangedEventArgs>((null, null, null, null),
                (1, false, "Parameter 'action' is null.", false));
            DDTRaisesEvent<PropertyChangedEventArgs>((null, pccObject, "PropertyChanged", null),
                (2, false, "Parameter 'action' is null.", false));
            DDTRaisesEvent<PropertyChangedEventArgs>((new Action(() => { }), null, "PropertyChanged", "() => { }"),
                (3, false, "Parameter 'object' is null.", false));
            DDTRaisesEvent<PropertyChangedEventArgs>((new Action(() => { }), pccObject, null, "() => { }"),
                (4, false, "Parameter 'eventName' is null or empty.", false));

            DDTRaisesEvent<PropertyChangedEventArgs>((new Action(() => { throw new Exception(); }), pccObject, "PropertyChanged", "() => { throw new Exception(); }"),
                (5, false, "Action threw Exception:", false));
            DDTRaisesEvent<PropertyChangedEventArgs>((new Action(() => { }), pccObject, "PropertyChanged_", "() => { }"),
                (6, false, "Event with name 'PropertyChanged_' could not be found.", false));
            DDTRaisesEvent<DoWorkEventArgs>((new Action(() => { }), pccObject, "PropertyChanged", "() => { }"),
                (7, false, "Given type of arguments 'System.ComponentModel.DoWorkEventArgs' doesn't match event handler of type 'System.ComponentModel.PropertyChangedEventHandler'.", false));

            DDTRaisesEvent<PropertyChangedEventArgs>((new Action(() => { }), pccObject, "PropertyChanged", "() => { }"),
                (8, false, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' raised.", false));
            DDTRaisesEvent<PropertyChangedEventArgs>((new Action(() => { pccObject.Value = !pccObject.Value; }), pccObject, "PropertyChanged", "() => { pccObject.Value = !pccObject.Value; }"),
                (9, true, "Event of type 'System.ComponentModel.PropertyChangedEventHandler' raised.", true));

        }

        void DDTRaisesEvent<TEventArgs>((Action action, INotifyPropertyChanged @object, String eventName, String actionString) input,
            (Int32 count, Boolean result, String message, Boolean eventRaised) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TEventArgs : EventArgs {

            Object sender = null;
            TEventArgs e = default;

            Test.Note($"Test.If.Action.RaisesEvent({input.actionString.Print()}, {input.@object.Print()}, {input.eventName.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Action.RaisesEvent(input.action, input.@object, input.eventName, out sender, out e, _file, _method),
                (expected.count, expected.result, expected.message), "Test.If.Action.RaisesEvent", _file, _method);

            if(expected.eventRaised) {
                Test.IfNot.Object.IsNull(sender, _file, _method);
                Test.If.ReferencesEqual(input.@object, sender, _file, _method);
                Test.IfNot.Object.IsNull(e, _file, _method);
            }

        }

        [TestMethod]
        void NotRaisesEvent() {

            PropertyChangedClass pccObject = new PropertyChangedClass();

            DDTNotRaisesEvent<PropertyChangedEventArgs>((null, null, null, null),
                (1, false, "Parameter 'action' is null.", false));
            DDTNotRaisesEvent<PropertyChangedEventArgs>((null, pccObject, "PropertyChanged", null),
                (2, false, "Parameter 'action' is null.", false));
            DDTNotRaisesEvent<PropertyChangedEventArgs>((new Action(() => { }), null, "PropertyChanged", "() => { }"),
                (3, false, "Parameter 'object' is null.", false));
            DDTNotRaisesEvent<PropertyChangedEventArgs>((new Action(() => { }), pccObject, null, "() => { }"),
                (4, false, "Parameter 'eventName' is null or empty.", false));

            DDTNotRaisesEvent<PropertyChangedEventArgs>((new Action(() => { throw new Exception(); }), pccObject, "PropertyChanged", "() => { throw new Exception(); }"),
                (5, false, "Action threw Exception:", false));
            DDTNotRaisesEvent<PropertyChangedEventArgs>((new Action(() => { }), pccObject, "PropertyChanged_", "() => { }"),
                (6, false, "Event with name 'PropertyChanged_' could not be found.", false));
            DDTNotRaisesEvent<DoWorkEventArgs>((new Action(() => { }), pccObject, "PropertyChanged", "() => { }"),
                (7, false, "Given type of arguments 'System.ComponentModel.DoWorkEventArgs' doesn't match event handler of type 'System.ComponentModel.PropertyChangedEventHandler'.", false));

            DDTNotRaisesEvent<PropertyChangedEventArgs>((new Action(() => { }), pccObject, "PropertyChanged", "() => { }"),
                (8, true, "No event of type 'System.ComponentModel.PropertyChangedEventHandler' raised.", false));
            DDTNotRaisesEvent<PropertyChangedEventArgs>((new Action(() => { pccObject.Value = !pccObject.Value; }), pccObject, "PropertyChanged", "() => { pccObject.Value = !pccObject.Value; }"),
                (9, false, "Event of type 'System.ComponentModel.PropertyChangedEventHandler' raised.", true));

        }

        void DDTNotRaisesEvent<TEventArgs>((Action action, INotifyPropertyChanged @object, String eventName, String actionString) input,
            (Int32 count, Boolean result, String message, Boolean eventRaised) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TEventArgs : EventArgs {

            Object sender = null;
            TEventArgs e = default;

            Test.Note($"Test.IfNot.Action.RaisesEvent({input.actionString.Print()}, {input.@object.Print()}, {input.eventName.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Action.RaisesEvent(input.action, input.@object, input.eventName, out sender, out e, _file, _method),
                (expected.count, expected.result, expected.message), "Test.IfNot.Action.RaisesEvent", _file, _method);

            if(expected.eventRaised) {
                Test.IfNot.Object.IsNull(sender, _file, _method);
                Test.If.ReferencesEqual(input.@object, sender, _file, _method);
                Test.IfNot.Object.IsNull(e, _file, _method);
            }

        }

        #endregion

    }
}
