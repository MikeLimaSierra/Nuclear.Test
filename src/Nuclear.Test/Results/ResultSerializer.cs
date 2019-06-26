using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Results {
    public static class ResultSerializer {

        #region serialize methods

        public static Byte[] Serialize(TestResultMap results) {
            using(MemoryStream ms = new MemoryStream()) {
                new BinaryFormatter().Serialize(ms, results.ToArray());
                return ms.ToArray();
            }
        }

        #endregion

        #region deserialize methods

        public static TestResultMap Deserialize(Byte[] buffer) {
            using(MemoryStream ms = new MemoryStream(buffer)) {
                return new TestResultMap(new BinaryFormatter().Deserialize(ms) as KeyValuePair<Tuple<String, ProcessorArchitecture, String, String>, TestResultCollection>[]);
            }
        }

        #endregion

    }
}
