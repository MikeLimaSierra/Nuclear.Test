namespace Nuclear.Test.Configurations {
    public class Configuration {

        #region properties

        public AssemblyLocatorConfiguration AssemblyLocatorConfiguration { get; } = new AssemblyLocatorConfiguration();

        public TestConfiguration TestConfiguration { get; } = new TestConfiguration();

        public OutputConfiguration OutputConfiguration { get; } = new OutputConfiguration();

        #endregion

    }
}
