using Nuclear.Test.Printer.Nodes;
using Nuclear.Test.Results;

namespace Nuclear.Test.Printer {

    /// <summary>
    /// Implements a tree structure used to display test results in a human readable way.
    /// </summary>
    public class ResultTree {

        #region properties

        /// <summary>
        /// Gets or sets the global <see cref="ColorScheme"/>.
        /// </summary>
        public static ColorScheme ColorScheme { get; set; } = ColorScheme = ColorScheme.Default;

        internal SummaryNode Node { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultTree"/>.
        /// </summary>
        /// <param name="verbosity">The desired verbosity of the tree.</param>
        /// <param name="key">The key that limits the contents of the tree.</param>
        /// <param name="results">The results that are shown in the tree.</param>
        public ResultTree(Verbosity verbosity, IResultKey key, ITestResultSource results) {
            Node = new SummaryNode(verbosity, key, results);
        }

        #endregion

        #region methods

        /// <summary>
        /// Prints the results.
        /// </summary>
        public void Print() => Node.Print(0);

        #endregion

    }
}
