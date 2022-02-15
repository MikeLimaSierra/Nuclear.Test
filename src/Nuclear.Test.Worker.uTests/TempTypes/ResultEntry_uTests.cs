using System;
using System.Collections.Generic;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.TempTypes {
    class ResultEntry_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<ResultEntry, IResultEntry>();

        }

        [TestMethod]
        [TestData(nameof(CtorThrows_Data))]
        void CtorThrows<TException>(EntryTypes in1, String in2, String in3, String expected)
            where TException : ArgumentException {

            TestX.If.Action.ThrowsException(() => new ResultEntry(in1, in2, in3), out TException ex);

            TestX.If.Value.IsEqual(ex.ParamName, expected);

        }

        IEnumerable<Object[]> CtorThrows_Data() {
            yield return new Object[] { typeof(ArgumentNullException), null, null, null, "message" };
            yield return new Object[] { typeof(ArgumentException), (EntryTypes) 42, null, null, "type" };
            yield return new Object[] { typeof(ArgumentNullException), EntryTypes.DataSource, null, null, "message" };
            yield return new Object[] { typeof(ArgumentNullException), EntryTypes.Error, null, null, "message" };
            yield return new Object[] { typeof(ArgumentNullException), EntryTypes.Injection, null, null, "message" };
            yield return new Object[] { typeof(ArgumentNullException), EntryTypes.Note, null, null, "message" };
            yield return new Object[] { typeof(ArgumentNullException), EntryTypes.ResultFail, null, null, "message" };
            yield return new Object[] { typeof(ArgumentNullException), EntryTypes.ResultOk, null, null, "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.DataSource, null, "", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Error, null, "", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Injection, null, "", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Note, null, "", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.ResultFail, null, "", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.ResultOk, null, "", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.DataSource, null, " ", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Error, null, " ", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Injection, null, " ", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Note, null, " ", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.ResultFail, null, " ", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.ResultOk, null, " ", "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Note, "", null, "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Note, " ", null, "message" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.Note, "Dummy_instruction", null, "message" };
            yield return new Object[] { typeof(ArgumentNullException), EntryTypes.ResultFail, null, "Dummy message.", "instruction" };
            yield return new Object[] { typeof(ArgumentNullException), EntryTypes.ResultOk, null, "Dummy message.", "instruction" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.ResultFail, "", "Dummy message.", "instruction" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.ResultOk, "", "Dummy message.", "instruction" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.ResultFail, " ", "Dummy message.", "instruction" };
            yield return new Object[] { typeof(ArgumentException), EntryTypes.ResultOk, " ", "Dummy message.", "instruction" };
        }

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(EntryTypes in1, String in2, String in3, String expectedInstruction) {

            IResultEntry sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new ResultEntry(in1, in2, in3), out Exception _);

            TestX.If.Value.IsEqual(sut.EntryType, in1);
            TestX.If.Value.IsEqual(sut.Instruction, expectedInstruction);
            TestX.If.Value.IsEqual(sut.Message, in3);

        }

        IEnumerable<Object[]> Ctor_Data() {
            yield return new Object[] { EntryTypes.DataSource, null, "Dummy message.", null };
            yield return new Object[] { EntryTypes.DataSource, "", "Dummy message.", null };
            yield return new Object[] { EntryTypes.DataSource, " ", "Dummy message.", null };
            yield return new Object[] { EntryTypes.DataSource, "Dummy_instruction", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Error, null, "Dummy message.", null };
            yield return new Object[] { EntryTypes.Error, "", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Error, " ", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Error, "Dummy_instruction", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Injection, null, "Dummy message.", null };
            yield return new Object[] { EntryTypes.Injection, "", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Injection, " ", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Injection, "Dummy_instruction", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Note, null, "Dummy message.", null };
            yield return new Object[] { EntryTypes.Note, "", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Note, " ", "Dummy message.", null };
            yield return new Object[] { EntryTypes.Note, "Dummy_instruction", "Dummy message.", null };
            yield return new Object[] { EntryTypes.ResultFail, "Dummy_instruction", "Dummy message.", "Dummy_instruction" };
            yield return new Object[] { EntryTypes.ResultOk, "Dummy_instruction", "Dummy message.", "Dummy_instruction" };
        }

    }
}
