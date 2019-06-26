using System;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.Tests {
    public partial class ConditionalTest {

        /// <summary>
        /// Tests if <paramref name="action"/> throws an <see cref="Exception"/> when executed.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        /// <param name="exception">Contains the exception if thrown.</param>
        public void ThrowsException(Action action, out Exception exception,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            exception = null;

            try {
                action();
            } catch(Exception ex) {
                exception = ex;
            } finally {
                InternalTest(exception != null, String.Format("[Exception = '{0}']", exception != null ? exception.ToString() : "null"),
                    _file, _method);
            }
        }

        /// <summary>
        /// Tests if <paramref name="action"/> throws an <see cref="Exception"/> of type <typeparamref name="TException"/> when executed.
        /// </summary>
        /// <typeparam name="TException">The expected type of exception.</typeparam>
        /// <param name="action">The action to be executed.</param>
        /// <param name="exception">Contains the exception if thrown.</param>
        public void ThrowsException<TException>(Action action, out TException exception,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            where TException : Exception {

            exception = null;

            try {
                action();
            } catch(TException ex) {
                exception = ex;
            } catch(Exception) {
                // don't care about all the other ones, this is just about TException!
            } finally {
                InternalTest(exception != null, String.Format("[Exception = '{0}']", exception != null ? exception.ToString() : "null"),
                    _file, _method);
            }
        }

    }
}
