using Nuclear.Test.ConsolePrinter.Tree.Nodes;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.ConsolePrinter.Tree {
    public class ResultTree {

        #region properties

        internal SummaryNode Node { get; private set; }

        #endregion

        #region ctors

        public ResultTree(PrintVerbosity verbosity, ITestResultSource results) {
            Node = new SummaryNode(verbosity, TestResultKey.Empty, results);
        }

        #endregion

        #region methods

        public void Print() => Node.Print();

        #endregion

    }
}
