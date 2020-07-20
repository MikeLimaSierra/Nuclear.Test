using System;
using System.IO;
using System.Reflection;
using System.Text;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Extensions {

    /// <summary>
    /// Extends the class <see cref="Stream"/> by adding general purpose read and write functionality.
    /// </summary>
    public static class StreamExtensions {

        #region read primitives

        /// <summary>
        /// Reads a <see cref="String"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="String"/> that was read from <paramref name="_this"/>.</returns>
        public static String ReadString(this Stream _this) {
            Byte[] lengthBuffer = new Byte[sizeof(UInt16)];
            _this.Read(lengthBuffer, 0, lengthBuffer.Length);

            Byte[] valueBuffer = new Byte[BitConverter.ToUInt16(lengthBuffer, 0)];
            _this.Read(valueBuffer, 0, valueBuffer.Length);

            return new UnicodeEncoding().GetString(valueBuffer);
        }

        /// <summary>
        /// Reads an <see cref="Int32"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="Int32"/> that was read from <paramref name="_this"/>.</returns>
        public static Int32 ReadInt32(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(Int32)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt32(buffer, 0);
        }

        /// <summary>
        /// Reads a <see cref="Boolean"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="Boolean"/> that was read from <paramref name="_this"/>.</returns>
        public static Boolean ReadBoolean(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(Boolean)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToBoolean(buffer, 0);
        }

        #endregion

        #region write primitives

        /// <summary>
        /// Writes a <see cref="String"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="String"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, String value) {
            value ??= String.Empty;
            Byte[] buffer = new UnicodeEncoding().GetBytes(value);
            UInt16 length = buffer.Length > UInt16.MaxValue ? UInt16.MaxValue : (UInt16) buffer.Length;
            _this.Write(BitConverter.GetBytes(length), 0, sizeof(UInt16));
            _this.Write(buffer, 0, length);
            _this.Flush();
        }

        /// <summary>
        /// Writes an <see cref="Int32"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Int32"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Int32 value) {
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Int32));
            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="Boolean"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Boolean"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Boolean value) {
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Boolean));
            _this.Flush();
        }

        #endregion

        #region custom reads

        /// <summary>
        /// Reads a <see cref="FrameworkIdentifiers"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <returns>The read value.</returns>
        public static FrameworkIdentifiers ReadMonikers(this Stream _this) => (FrameworkIdentifiers) _this.ReadInt32();

        /// <summary>
        /// Reads a <see cref="ProcessorArchitecture"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <returns>The read value.</returns>
        public static ProcessorArchitecture ReadArchitecture(this Stream _this) => (ProcessorArchitecture) _this.ReadInt32();

        /// <summary>
        /// Reads a <see cref="ITestResultKey"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="ITestResultKey"/> that was read from <paramref name="_this"/>.</returns>
        public static ITestResultKey ReadResultKey(this Stream _this)
            => new TestResultKey(_this.ReadString(),
                new RuntimeInfo(_this.ReadMonikers(), new Version(_this.ReadString())), _this.ReadArchitecture(),
                new RuntimeInfo(_this.ReadMonikers(), new Version(_this.ReadString())), _this.ReadArchitecture(),
                _this.ReadString(), _this.ReadString());

        /// <summary>
        /// Reads a <see cref="ITestEntry"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="ITestEntry"/> that was read from <paramref name="_this"/>.</returns>
        public static ITestEntry ReadTestResult(this Stream _this)
            => new TestEntry((EntryTypes) _this.ReadInt32(), _this.ReadBoolean() ? _this.ReadString() : null, _this.ReadString());

        /// <summary>
        /// Reads a <see cref="ITestMethodResult"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="ITestMethodResult"/> that was read from <paramref name="_this"/>.</returns>
        public static ITestMethodResult ReadTestResults(this Stream _this) {
            ITestMethodResult results = new TestMethodResult();
            results.Ignore(_this.ReadString());
            Int32 count = _this.ReadInt32();

            for(Int32 i = 0; i < count; i++) {
                results.TestEntries.Add(_this.ReadTestResult());
            }

            return results;
        }

        #endregion

        #region custom writes

        /// <summary>
        /// Writes an <see cref="FrameworkIdentifiers"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="FrameworkIdentifiers"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, FrameworkIdentifiers value) => _this.Write((Int32) value);

        /// <summary>
        /// Writes an <see cref="ProcessorArchitecture"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="ProcessorArchitecture"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, ProcessorArchitecture value) => _this.Write((Int32) value);

        /// <summary>
        /// Writes a <see cref="ITestResultKey"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="key">The <see cref="ITestResultKey"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, ITestResultKey key) {
            _this.Write(key.AssemblyName);
            _this.Write(key.TargetRuntime.Framework);
            _this.Write(key.TargetRuntime.Version.ToString());
            _this.Write(key.TargetArchitecture);
            _this.Write(key.ExecutionRuntime.Framework);
            _this.Write(key.ExecutionRuntime.Version.ToString());
            _this.Write(key.ExecutionArchitecture);
            _this.Write(key.FileName);
            _this.Write(key.MethodName);
        }

        /// <summary>
        /// Writes a <see cref="ITestEntry"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="ITestEntry"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, ITestEntry value) {
            _this.Write((Int32) value.EntryType);

            if(value.Instruction == null) {
                _this.Write(false);

            } else {
                _this.Write(true);
                _this.Write(value.Instruction);
            }

            _this.Write(value.Message);
        }

        /// <summary>
        /// Writes a <see cref="ITestMethodResult"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="values">The <see cref="ITestMethodResult"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, ITestMethodResult values) {
            _this.Write(values.IgnoreReason);
            _this.Write(values.TestEntries.Count);
            values.TestEntries.Foreach(value => _this.Write(value));
        }

        #endregion

    }
}
