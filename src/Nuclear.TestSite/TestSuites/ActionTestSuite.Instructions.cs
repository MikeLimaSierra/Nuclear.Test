using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    public partial class ActionTestSuite {

        #region exceptions

        /// <summary>
        /// Tests if <paramref name="action"/> throws an <see cref="Exception"/> of type <typeparamref name="TException"/> when executed.
        /// </summary>
        /// <typeparam name="TException">The expected type of exception.</typeparam>
        /// <param name="action">The action to be executed.</param>
        /// <param name="exception">Contains the exception if thrown.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Action.ThrowsException&lt;ArgumentException&gt;(() => obj.DoSomething(), out ArgumentException exception);
        /// </code>
        /// </example>
        public void ThrowsException<TException>(Action action, out TException exception,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TException : Exception {

            exception = null;

            if(action == null) {
                FailTest("Parameter 'action' is null.", _file, _method);
                return;
            }

            try {
                action();
            } catch(TException ex) {
                exception = ex;
            } catch(Exception) {
                // don't care about all the other ones, this is just about TException!
            } finally {
                InternalTest(exception != null, $"[Exception = {exception.Print()}]",
                    _file, _method);
            }
        }

        #endregion

        #region events

        /// <summary>
        /// Tests if <paramref name="action"/> on <paramref name="object"/> raises <see cref="INotifyPropertyChanged"/>.
        /// </summary>
        /// <param name="action">The action to be invoked on <paramref name="object"/>.</param>
        /// <param name="object">The object to invoke <paramref name="action"/> on.</param>
        /// <param name="sender">Contains the sender if event is raised.</param>
        /// <param name="e">Contains the <see cref="PropertyChangedEventArgs"/> if event is raised.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Action.RaisesPropertyChangedEvent(() => obj.Title = "new content", obj, out Object sender, out PropertyChangedEventArgs e);
        /// </code>
        /// </example>
        public void RaisesPropertyChangedEvent(Action action, INotifyPropertyChanged @object, out Object sender, out PropertyChangedEventArgs e,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            sender = null;
            e = null;

            if(action == null) {
                FailTest("Parameter 'action' is null.", _file, _method);
                return;
            }

            if(@object == null) {
                FailTest("Parameter 'object' is null.", _file, _method);
                return;
            }

            (Object sender, PropertyChangedEventArgs e) tmp = (null, null);

            void handler(Object _sender, PropertyChangedEventArgs _e) => tmp = (_sender, _e);

            @object.PropertyChanged += handler;

            try {
                action();
                sender = tmp.sender;
                e = tmp.e;

                InternalTest(sender != null && e != null, String.Format("{0} of type {1} raised.", sender != null && e != null ? "Event" : "No event", typeof(PropertyChangedEventHandler).Print()),
                    _file, _method);

            } catch(Exception ex) {
                FailTest($"Action threw Exception: {ex.Message.Print()}",
                    _file, _method);
                return;

            } finally {
                @object.PropertyChanged -= handler;
            }
        }

        /// <summary>
        /// Tests if <paramref name="action"/> on <paramref name="object"/> raises event with <typeparamref name="TEventArgs"/>.
        /// </summary>
        /// <typeparam name="TEventArgs">The expected type of event arguments.</typeparam>
        /// <param name="action">The action to be invoked on <paramref name="object"/>.</param>
        /// <param name="object">The object to invoke <paramref name="action"/> on.</param>
        /// <param name="eventName">The name of the event to be raised.</param>
        /// <param name="sender">Contains the sender if event is raised.</param>
        /// <param name="e">Contains the <typeparamref name="TEventArgs"/> if event is raised.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Action.RaisesEvent(() => obj.DoSomething(), obj, "MyCustomEvent", out Object sender, out MyCustomEventArgs e);
        /// </code>
        /// </example>
        public void RaisesEvent<TEventArgs>(Action action, Object @object, String eventName, out Object sender, out TEventArgs e,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TEventArgs : EventArgs {

            sender = null;
            e = null;

            if(action == null) {
                FailTest("Parameter 'action' is null.", _file, _method);
                return;
            }

            if(@object == null) {
                FailTest("Parameter 'object' is null.", _file, _method);
                return;
            }

            if(String.IsNullOrWhiteSpace(eventName)) {
                FailTest("Parameter 'eventName' is null or empty.", _file, _method);
                return;
            }

            Delegate d = null;

            EventProxy<TEventArgs> eventProxy = new EventProxy<TEventArgs>();
            MethodInfo handlerInfo = eventProxy.GetType().GetRuntimeMethods().First(method => method.Name == "OnEventRaised");

            EventInfo eventInfo = @object.GetType().GetRuntimeEvent(eventName);

            if(eventInfo == null) {
                FailTest($"Event with name {eventName.Print()} could not be found.",
                    _file, _method);
                return;
            }

            try {
                d = Delegate.CreateDelegate(eventInfo.EventHandlerType, eventProxy, handlerInfo);

            } catch {
                FailTest($"Given type of arguments {typeof(TEventArgs).Print()} doesn't match event handler of type {eventInfo.EventHandlerType.Print()}.",
                    _file, _method);
                return;
            }

            eventInfo.GetAddMethod().Invoke(@object, new Object[] { d });

            try {
                action();
                sender = eventProxy.Sender;
                e = eventProxy.EventArgs;

                InternalTest(sender != null && e != null, String.Format("{0} of type '{1}' raised.", sender != null && e != null ? "Event" : "No event", eventInfo.EventHandlerType.FullName),
                    _file, _method);

            } catch(Exception ex) {
                FailTest($"Action threw Exception: {ex.Message.Print()}",
                    _file, _method);
                return;

            } finally {
                eventInfo.GetRemoveMethod().Invoke(@object, new Object[] { d });
            }
        }

        private class EventProxy<TEventArgs>
            where TEventArgs : EventArgs {

            internal Object Sender { get; private set; }

            internal TEventArgs EventArgs { get; private set; }

            internal void OnEventRaised(Object sender, TEventArgs e) {
                Sender = sender;
                EventArgs = e;
            }

        }

        #endregion

    }
}
