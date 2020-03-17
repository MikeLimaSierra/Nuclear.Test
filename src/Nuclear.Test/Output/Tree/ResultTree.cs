using Nuclear.Test.ConsolePrinter.Tree.Nodes;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree {
    public class ResultTree {

        #region properties

        /// <summary>
        /// Gets or sets the global <see cref="TreeColorScheme"/>.
        /// </summary>
        public static TreeColorScheme ColorScheme { get; set; } = ColorScheme = TreeColorScheme.Default;

        internal SummaryNode Node { get; private set; }

        #endregion

        #region ctors

        public ResultTree(PrintVerbosity verbosity, ITestResultSource results) {
            Node = new SummaryNode(verbosity, TestResultKey.Empty, results);
        }

        #endregion

        #region methods

        public void PrintResults() => Node.Print(0);

        #endregion

    }
}
