using ChatterBot.Config;

namespace ChatterBot.Tests.Builders
{
    public class FakeSettingsBuilder
    {
        private string _entropy = "";
        private string _lightDbConnection = "";

        private FakeSettingsBuilder()
        {
        }

        public static FakeSettingsBuilder New()
        {
            return new FakeSettingsBuilder();
        }

        public ApplicationSettings Build()
        {
            return new ApplicationSettings
            {
                Entropy = _entropy,
                LightDbConnection = _lightDbConnection,
            };
        }

        public FakeSettingsBuilder WithTestData()
            => WithEntropy("EntropicEntropy")
                .WithConnection("Filename=:memory:");

        public FakeSettingsBuilder WithEntropy(string entropy)
        {
            _entropy = entropy;
            return this;
        }

        public FakeSettingsBuilder WithConnection(string connection)
        {
            _lightDbConnection = connection;
            return this;
        }
    }
}