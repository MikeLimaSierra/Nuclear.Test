using System;
using System.IO;
using System.IO.Pipes;

using Nuclear.Test.Configurations;
using Nuclear.Test.Printer;

namespace Nuclear.Test.Extensions {

    /// <summary>
    /// Extends the class <see cref="PipeStream"/> by adding general purpose read and write functionality.
    /// </summary>
    public static class PipeStreamExtensions {

        #region read complex

        /// <summary>
        /// Reads an <see cref="Array"/> of bytes from a <see cref="PipeStream"/> using one ore more messages.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to read from.</param>
        /// <returns>The <see cref="Array"/> of bytes that was read from <paramref name="_this"/>.</returns>
        public static Byte[] ReadLarge(this PipeStream _this) {
            Int32 length = _this.ReadInt32();

            using(MemoryStream ms = new MemoryStream()) {
                for(Int32 i = 0; i < length; i += UInt16.MaxValue) {
                    Byte[] buffer = new Byte[Math.Min(length - i, UInt16.MaxValue)];
                    _this.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, buffer.Length);
                }

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Reads a <see cref="FileInfo"/> from a <see cref="PipeStream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to read from.</param>
        /// <returns>The <see cref="FileInfo"/> that was read from <paramref name="_this"/>.</returns>
        public static FileInfo ReadFileInfo(this PipeStream _this) => new FileInfo(_this.ReadString());

        /// <summary>
        /// Reads a <see cref="DirectoryInfo"/> from a <see cref="PipeStream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to read from.</param>
        /// <returns>The <see cref="DirectoryInfo"/> that was read from <paramref name="_this"/>.</returns>
        public static DirectoryInfo ReadDirectoryInfo(this PipeStream _this) => new DirectoryInfo(_this.ReadString());

        /// <summary>
        /// Reads a <see cref="TestConfiguration"/> from a <see cref="PipeStream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to read from.</param>
        /// <param name="command">The command that describes, which value to read.</param>
        /// <param name="config">The <see cref="TestConfiguration"/> to store new values to.</param>
        /// <param name="value">The value that was read in its <see cref="String"/> representation.</param>
        /// <returns>True if a value was read, false if not.</returns>
        public static Boolean ReadConfiguration(this PipeStream _this, String command, TestConfiguration config, out String value) {
            switch(command) {
                case TestConfiguration.FORCE_SEQUENTIAL:
                    config.ForceSequential = _this.ReadBoolean();
                    value = config.ForceSequential.ToString();
                    break;
                case TestConfiguration.FORCE_ASM_SEQUENTIAL:
                    config.ForceAsmSequential = _this.ReadBoolean();
                    value = config.ForceAsmSequential.ToString();
                    break;
                case TestConfiguration.WORKER_BASE_DIR:
                    config.WorkerBaseDir = _this.ReadDirectoryInfo();
                    value = config.WorkerBaseDir.ToString();
                    break;
                case TestConfiguration.PROXY_BASE_DIR:
                    config.ProxyBaseDir = _this.ReadDirectoryInfo();
                    value = config.ProxyBaseDir.ToString();
                    break;
                case TestConfiguration.TEST_ALL_VERSIONS:
                    config.TestAllVersions = _this.ReadBoolean();
                    value = config.TestAllVersions.ToString();
                    break;
                default:
                    value = String.Empty;
                    break;
            }

            return !String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Reads an <see cref="OutputConfiguration"/> from a <see cref="PipeStream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to read from.</param>
        /// <param name="command">The command that describes, which value to read.</param>
        /// <param name="config">The <see cref="OutputConfiguration"/> to store new values to.</param>
        /// <param name="value">The value that was read in its <see cref="String"/> representation.</param>
        /// <returns>True if a value was read, false if not.</returns>
        public static Boolean ReadConfiguration(this PipeStream _this, String command, OutputConfiguration config, out String value) {
            switch(command) {
                case OutputConfiguration.DIAGNOSTIC_OUTPUT:
                    config.DiagnosticOutput = _this.ReadBoolean();
                    value = config.DiagnosticOutput.ToString();
                    break;
                case OutputConfiguration.VERBOSITY:
                    config.Verbosity = (Verbosity) _this.ReadInt32();
                    value = config.Verbosity.ToString();
                    break;
                case OutputConfiguration.SHOW_CLIENTS:
                    config.ShowClients = _this.ReadBoolean();
                    value = config.ShowClients.ToString();
                    break;
                case OutputConfiguration.CLIENTS_AWAIT_INPUT:
                    config.ClientsAwaitInput = _this.ReadBoolean();
                    value = config.ClientsAwaitInput.ToString();
                    break;
                default:
                    value = String.Empty;
                    break;
            }

            return !String.IsNullOrEmpty(value);
        }

        #endregion

        #region write complex

        /// <summary>
        /// Writes an <see cref="Array"/> of bytes to a <see cref="PipeStream"/> using one ore more messages.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to write to.</param>
        /// <param name="value">The <see cref="Array"/> that is written to <paramref name="_this"/>.</param>
        public static void WriteLarge(this PipeStream _this, Byte[] value) {
            _this.Write(value.Length);

            for(Int32 i = 0; i < value.Length; i += UInt16.MaxValue) {
                _this.Write(value, i, Math.Min(value.Length - i, UInt16.MaxValue));
            }

            _this.Flush();
        }

        /// <summary>
        /// Writes a <see cref="FileInfo"/> to a <see cref="PipeStream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to write to.</param>
        /// <param name="value">The <see cref="FileInfo"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this PipeStream _this, FileInfo value) => _this.Write(value.FullName);

        /// <summary>
        /// Writes a <see cref="DirectoryInfo"/> to a <see cref="PipeStream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to write to.</param>
        /// <param name="value">The <see cref="DirectoryInfo"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this PipeStream _this, DirectoryInfo value) => _this.Write(value.FullName);

        /// <summary>
        /// Writes a <see cref="TestConfiguration"/> to a <see cref="PipeStream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to write to.</param>
        /// <param name="config">The <see cref="TestConfiguration"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this PipeStream _this, TestConfiguration config) {
            _this.Write(TestConfiguration.FORCE_SEQUENTIAL);
            _this.Write(config.ForceSequential);

            _this.Write(TestConfiguration.FORCE_ASM_SEQUENTIAL);
            _this.Write(config.ForceAsmSequential);

            _this.Write(TestConfiguration.WORKER_BASE_DIR);
            _this.Write(config.WorkerBaseDir);

            _this.Write(TestConfiguration.PROXY_BASE_DIR);
            _this.Write(config.ProxyBaseDir);

            _this.Write(TestConfiguration.TEST_ALL_VERSIONS);
            _this.Write(config.TestAllVersions);
        }

        /// <summary>
        /// Writes an <see cref="OutputConfiguration"/> to a <see cref="PipeStream"/>.
        /// </summary>
        /// <param name="_this">The <see cref="PipeStream"/> to write to.</param>
        /// <param name="config">The <see cref="OutputConfiguration"/> that is written to <paramref name="_this"/>.</param>
        public static void Write(this PipeStream _this, OutputConfiguration config) {
            _this.Write(OutputConfiguration.DIAGNOSTIC_OUTPUT);
            _this.Write(config.DiagnosticOutput);

            _this.Write(OutputConfiguration.VERBOSITY);
            _this.Write((Int32) config.Verbosity);

            _this.Write(OutputConfiguration.SHOW_CLIENTS);
            _this.Write(config.ShowClients);

            _this.Write(OutputConfiguration.CLIENTS_AWAIT_INPUT);
            _this.Write(config.ClientsAwaitInput);
        }

        #endregion

    }
}
