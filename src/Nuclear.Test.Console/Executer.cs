using Nuclear.Exceptions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Console {
    internal class Executer {

        #region fields

        private readonly Configuration _configuration;

        private readonly IFactory _factory;

        #endregion

        #region properties

        internal ITestResultEndPoint Results { get; }

        #endregion

        #region ctors

        public Executer(Configuration configuration, IFactory factory) {
            Throw.If.Object.IsNull(configuration, nameof(configuration));
            Throw.If.Object.IsNull(factory, nameof(factory));

            _configuration = configuration;
            _factory = factory;

            _factory.Create(out ITestResultEndPoint results);
            Results = results;
        }

        #endregion

        #region methods

        internal void Execute() {
            // todo
        }

        #endregion

    }
}
