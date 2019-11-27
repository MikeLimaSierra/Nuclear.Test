using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuclear.Test.Extensions;
using Nuclear.Test.Output;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Implements serialization and deserialization functionality for <see cref="TestResults"/>.
    /// </summary>
    public static class ResultSerializer {

        #region serialize methods

        /// <summary>
        /// Serializes a given <see cref="TestResults"/> to an <see cref="Array"/> of bytes.
        /// </summary>
        /// <param name="results">The <see cref="TestResults"/> to serialize.</param>
        /// <returns>The <see cref="Array"/> of bytes after successful serialization.</returns>
        public static Byte[] Serialize(TestResults results) {
            using(MemoryStream ms = new MemoryStream()) {
                IEnumerable<KeyValuePair<TestResultKey, TestMethodResult>> values = results.Values;

                ms.Write(values.Count());

                foreach(KeyValuePair<TestResultKey, TestMethodResult> result in values) {
                    ms.Write(result.Key);
                    ms.Write(result.Value);
                }

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Serializes a given <see cref="TestResults"/> to an <see cref="Array"/> of bytes.
        /// </summary>
        /// <param name="results">The <see cref="TestResults"/> to serialize.</param>
        /// <param name="data">The <see cref="Array"/> of bytes after successful serialization.</param>
        /// <returns>True if serialization was successful.</returns>
        public static Boolean TrySerialize(TestResults results, out Byte[] data) {
            data = null;

            try {
                data = Serialize(results);

            } catch(Exception ex) {
                // this should work flawlessly
                DiagnosticOutput.LogError("Serialization of results failed with exception: {0}.", ex);
            }

            return data != null && data.Length > 0;
        }

        #endregion

        #region deserialize methods

        /// <summary>
        /// Deserializes a given <see cref="Array"/> of bytes to a <see cref="TestResults"/>.
        /// </summary>
        /// <param name="data">The <see cref="Array"/> of bytes to deserialize.</param>
        /// <returns>The <see cref="TestResults"/> after successful deserialization.</returns>
        public static TestResults Deserialize(Byte[] data) {
            using(MemoryStream ms = new MemoryStream(data)) {
                TestResults results = new TestResults();
                Int32 count = ms.ReadInt32();

                for(Int32 i = 0; i < count; i++) {
                    results.Add(ms.ReadResultKey(), ms.ReadTestResults());
                }

                return results;
            }
        }

        /// <summary>
        /// Deserializes a given <see cref="Array"/> of bytes to a <see cref="TestResults"/>.
        /// </summary>
        /// <param name="data">The <see cref="Array"/> of bytes to deserialize.</param>
        /// <param name="results">The <see cref="TestResults"/> after successful deserialization.</param>
        /// <returns>True if deserialization was successful.</returns>
        public static Boolean TryDeserialize(Byte[] data, out TestResults results) {
            results = null;

            try {
                results = Deserialize(data);

            } catch(Exception ex) {
                // this should work flawlessly
                DiagnosticOutput.LogError("Deserialization of results failed with exception: {0}.", ex);
            }

            return results != null;
        }

        #endregion

    }
}
