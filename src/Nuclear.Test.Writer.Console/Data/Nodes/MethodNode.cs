using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;
using Nuclear.Test.Writer.Console.Data.Leafs;

namespace Nuclear.Test.Writer.Console.Data.Nodes {
    internal class MethodNode : TreeNode {

        #region properties

        internal Boolean IsIgnored { get; private set; }

        internal String IgnoreReason { get; private set; }

        internal Boolean IsEmpty { get; private set; }

        internal Boolean IsFailed { get; private set; }

        #endregion

        #region ctors

        internal MethodNode(String name, Verbosity verbosity, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results)
            : base(name, verbosity, results) {

            if(verbosity > Verbosity.MethodName || HasFails || HasIgnores || HasBlanks) {
                ITestMethodResult result = results.First().Value;

                Int32 index = 1;
                IsIgnored = result.IsIgnored;
                IgnoreReason = result.IgnoreReason;
                IsEmpty = result.IsEmpty;
                IsFailed = result.IsFailed;

                foreach(ITestEntry entry in result.TestEntries) {
                    if(entry.EntryType == EntryTypes.Error) {
                        Children.Add(new ErrorLeaf("Error", entry));

                    } else if(entry.EntryType == EntryTypes.Note) {
                        Children.Add(new NoteLeaf("Note", entry));

                    } else if(entry.EntryType == EntryTypes.Injection) {
                        Children.Add(new InjectionLeaf("Parameter Injection", entry));

                    } else {
                        Children.Add(new ResultLeaf($"#{index++}: {entry.Instruction}", entry));
                    }
                }
            }
        }

        #endregion

        #region methods

        protected override void WriteResult() {
            if(IsIgnored) {
                ConsoleAdapter.Write(Writer.Colors.IgnoreMessage, IgnoreReason);

            } else if(IsEmpty && !IsFailed) {
                ConsoleAdapter.Write(Writer.Colors.StateEmpty, "Method has no test instructions!");

            } else if(IsFailed) {
                ConsoleAdapter.Write(Writer.Colors.StateFailed, "Failed");

            } else {
                ConsoleAdapter.Write(Writer.Colors.StateOk, "Ok");
            }
        }

        protected override void WriteDetails() {
            if(!IsEmpty) {
                base.WriteDetails();
            }
        }

        #endregion

    }
}
