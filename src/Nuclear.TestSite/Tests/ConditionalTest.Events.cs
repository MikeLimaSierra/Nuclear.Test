using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.Tests {
    public partial class ConditionalTest {

        /// <summary>
        /// Tests if <paramref name="action"/> on <paramref name="_object"/> raises <see cref="INotifyPropertyChanged"/>.
        /// </summary>
        /// <param name="_object">The object to invoke <paramref name="action"/> on.</param>
        /// <param name="action">The action to be invoked on <paramref name="_object"/>.</param>
        /// <param name="sender">Contains the sender if event is raised.</param>
        /// <param name="e">Contains the <see cref="PropertyChangedEventArgs"/> if event is raised.</param>
        public void RaisesPropertyChangedEvent(INotifyPropertyChanged _object, Action action, out Object sender, out PropertyChangedEventArgs e,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => RaisesEvent(_object, "PropertyChanged", action, out sender, out e,
                _file, _method, conditionTestOverride: "RaisesPropertyChangedEvent");

        /// <summary>
        /// Tests if <paramref name="action"/> on <paramref name="_object"/> raises event with <typeparamref name="TEventArgs"/>.
        /// </summary>
        /// <typeparam name="TEventArgs">The expected type of event arguments.</typeparam>
        /// <param name="_object">The object to invoke <paramref name="action"/> on.</param>
        /// <param name="eventName">The name of the event to be raised.</param>
        /// <param name="action">The action to be invoked on <paramref name="_object"/>.</param>
        /// <param name="sender">Contains the sender if event is raised.</param>
        /// <param name="e">Contains the <typeparamref name="TEventArgs"/> if event is raised.</param>
        public void RaisesEvent<TEventArgs>(Object _object, String eventName, Action action, out Object sender, out TEventArgs e,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null, String conditionTestOverride = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            where TEventArgs : EventArgs {

            sender = null;
            e = null;
            Delegate d = null;

            if(_object == null) {
                InternalTest(false, "Object is null.",
                    _file, _method, testInstructionOverride: conditionTestOverride);
                return;
            }

            EventProxy<TEventArgs> eventProxy = new EventProxy<TEventArgs>();
            MethodInfo handlerInfo = eventProxy.GetType().GetRuntimeMethods().First(method => method.Name == "OnEventRaised");

            EventInfo eventInfo = _object.GetType().GetRuntimeEvent(eventName);

            if(eventInfo == null) {
                InternalTest(false, String.Format("Event with name '{0}' could not be found.", eventName),
                    _file, _method, testInstructionOverride: conditionTestOverride);
                return;
            }

            try {
                d = Delegate.CreateDelegate(eventInfo.EventHandlerType, eventProxy, handlerInfo);
            } catch {
                InternalTest(false, String.Format("Given type of arguments '{0}' doesn't match event handler of type '{1}'.", typeof(TEventArgs).FullName, eventInfo.EventHandlerType.FullName),
                    _file, _method, testInstructionOverride: conditionTestOverride);
                return;
            }

            eventInfo.GetAddMethod().Invoke(_object, new Object[] { d });

            try {
                action();
                sender = eventProxy.Sender;
                e = eventProxy.EventArgs;
                InternalTest(sender != null && e != null, String.Format("{0} of type '{1}' thrown.", sender != null && e != null ? "Event" : "No event", eventInfo.EventHandlerType.FullName),
                    _file, _method, testInstructionOverride: conditionTestOverride);
            } catch(Exception ex) {
                InternalTest(false, String.Format("Action threw Exception: {0}", ex.Message),
                    _file, _method, testInstructionOverride: conditionTestOverride);
                return;
            } finally {
                eventInfo.GetRemoveMethod().Invoke(_object, new Object[] { d });
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

    }
}
