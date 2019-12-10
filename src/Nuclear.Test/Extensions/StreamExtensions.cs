using System;
using System.IO;
using System.Reflection;
using System.Text;
using Nuclear.Extensions;
using Nuclear.Test.Results;
using Nuclear.TestSite;

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
        /// Reads an <see cref="Int16"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="Int16"/> that was read from <paramref name="_this"/>.</returns>
        public static Int16 ReadInt16(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(Int16)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt16(buffer, 0);
        }

        /// <summary>
        /// Reads a <see cref="UInt16"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="UInt16"/> that was read from <paramref name="_this"/>.</returns>
        public static UInt16 ReadUInt16(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(UInt16)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt16(buffer, 0);
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
        /// Reads a <see cref="UInt32"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="UInt32"/> that was read from <paramref name="_this"/>.</returns>
        public static UInt32 ReadUInt32(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(UInt32)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt32(buffer, 0);
        }

        /// <summary>
        /// Reads an <see cref="Int64"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="Int64"/> that was read from <paramref name="_this"/>.</returns>
        public static Int64 ReadInt64(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(Int64)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// Reads a <see cref="UInt64"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="UInt64"/> that was read from <paramref name="_this"/>.</returns>
        public static UInt64 ReadUInt64(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(UInt64)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt64(buffer, 0);
        }

        /// <summary>
        /// Reads a <see cref="Single"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="Single"/> that was read from <paramref name="_this"/>.</returns>
        public static Single ReadSingle(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(Single)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToSingle(buffer, 0);
        }

        /// <summary>
        /// Reads a <see cref="Double"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="Double"/> that was read from <paramref name="_this"/>.</returns>
        public static Double ReadDouble(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(Double)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToDouble(buffer, 0);
        }

        /// <summary>
        /// Reads a <see cref="Char"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="Char"/> that was read from <paramref name="_this"/>.</returns>
        public static Char ReadChar(this Stream _this) {
            Byte[] buffer = new Byte[sizeof(Char)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToChar(buffer, 0);
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
            value = value ?? String.Empty;
            Byte[] buffer = new UnicodeEncoding().GetBytes(value);
            UInt16 length = buffer.Length > UInt16.MaxValue ? UInt16.MaxValue : (UInt16) buffer.Length;
            _this.Write(BitConverter.GetBytes(length), 0, sizeof(UInt16));
            _this.Write(buffer, 0, length);
            _this.Flush();
        }

        /// <summary>
        /// Writes an <see cref="Int16"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Int16"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Int16 value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Int16));
            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="UInt16"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="UInt16"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, UInt16 value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(UInt16));
            _this.Flush();
        }

        /// <summary>
        /// Writes an <see cref="Int32"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Int32"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Int32 value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Int32));
            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="UInt32"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="UInt32"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, UInt32 value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(UInt32));
            _this.Flush();
        }

        /// <summary>
        /// Writes an <see cref="Int64"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Int64"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Int64 value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Int64));
            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="UInt64"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="UInt64"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, UInt64 value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(UInt64));
            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="Single"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Single"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Single value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Single));
            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="Double"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Double"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Double value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Double));
            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="Char"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Char"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Char value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Char));
            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="Boolean"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="Boolean"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, Boolean value) {
            Byte[] buffer = BitConverter.GetBytes(value);
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
        public static FrameworkIdentifiers ReadMonikers(this Stream _this)
            => (FrameworkIdentifiers) _this.ReadInt32();

        /// <summary>
        /// Reads a <see cref="ProcessorArchitecture"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <returns>The read value.</returns>
        public static ProcessorArchitecture ReadArchitecture(this Stream _this)
            => (ProcessorArchitecture) _this.ReadInt32();

        /// <summary>
        /// Reads a <see cref="ITestResultKey"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="ITestResultKey"/> that was read from <paramref name="_this"/>.</returns>
        public static ITestResultKey ReadResultKey(this Stream _this)
            => new TestResultKey(_this.ReadString(),
                _this.ReadMonikers(), new Version(_this.ReadString()), _this.ReadArchitecture(),
                _this.ReadMonikers(), new Version(_this.ReadString()), _this.ReadArchitecture(),
                _this.ReadString(), _this.ReadString());

        /// <summary>
        /// Reads a <see cref="ITestInstructionResult"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="ITestInstructionResult"/> that was read from <paramref name="_this"/>.</returns>
        public static ITestInstructionResult ReadTestResult(this Stream _this) {
            Boolean isResult = _this.ReadBoolean();
            if(isResult) {
                return new TestInstructionResult(_this.ReadBoolean(), _this.ReadString(), _this.ReadString());
            } else {
                return new TestInstructionResult(_this.ReadString());
            }
        }

        /// <summary>
        /// Reads a <see cref="ITestMethodResult"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to read from.</param>
        /// <returns>The <see cref="ITestMethodResult"/> that was read from <paramref name="_this"/>.</returns>
        public static ITestMethodResult ReadTestResults(this Stream _this) {
            ITestMethodResult results = new TestMethodResult();
            results.Fail(_this.ReadString());
            Int32 count = _this.ReadInt32();

            for(Int32 i = 0; i < count; i++) {
                results.InstructionResults.Add(_this.ReadTestResult());
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
        public static void Write(this Stream _this, FrameworkIdentifiers value)
            => _this.Write((Int32) value);

        /// <summary>
        /// Writes an <see cref="ProcessorArchitecture"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="ProcessorArchitecture"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, ProcessorArchitecture value)
            => _this.Write((Int32) value);

        /// <summary>
        /// Writes a <see cref="ITestResultKey"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="key">The <see cref="ITestResultKey"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, ITestResultKey key) {
            _this.Write(key.AssemblyName);
            _this.Write(key.TargetFrameworkIdentifier);
            _this.Write(key.TargetFrameworkVersion.ToString());
            _this.Write(key.TargetArchitecture);
            _this.Write(key.ExecutionFrameworkIdentifier);
            _this.Write(key.ExecutionFrameworkVersion.ToString());
            _this.Write(key.ExecutionArchitecture);
            _this.Write(key.FileName);
            _this.Write(key.MethodName);
        }

        /// <summary>
        /// Writes a <see cref="ITestInstructionResult"/> to a <see cref="Stream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Stream"/> to write to.</param>
        /// <param name="value">The <see cref="ITestInstructionResult"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this Stream _this, ITestInstructionResult value) {
            _this.Write(value.Result.HasValue);

            if(value.Result.HasValue) {
                _this.Write(value.Result.Value);
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
            _this.Write(values.FailMessage);
            _this.Write(values.InstructionResults.Count);
            values.InstructionResults.ForEach(value => _this.Write(value));
        }

        #endregion

    }
}
