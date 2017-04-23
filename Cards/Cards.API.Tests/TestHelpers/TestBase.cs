using Microsoft.Extensions.Configuration;
using Nancy.Bootstrapper;
using Nancy.Testing;
using Cards.API.BusinessLogic.Settings;
using System;
using System.IO;
using System.Reflection;

namespace Cards.API.Tests.TestHelpers
{
    public abstract class TestBase
    {
        private IConfiguration _config { get; set; }
        private INancyBootstrapper _bootstrapper { get; set; }
        private Browser _browser { get; set; }

        public TestBase()
        {
            var location = typeof(TestBase).GetTypeInfo().Assembly.Location;
            var directory = Path.GetDirectoryName(location).Split(new string[] { "bin" }, StringSplitOptions.None);

            var builder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(directory[0], "appsettings.Test.json"));

            _config = builder.Build();

            var appSettings = new ApplicationSettings();
            ConfigurationBinder.Bind(_config, appSettings);

            _bootstrapper = new Bootstrapper(appSettings, new MockServiceProvider());
            _browser = new Browser(_bootstrapper);
        }

        public IConfiguration Configuration
        {
            get => _config;
        }

        public INancyBootstrapper Bootstrapper
        {
            get => _bootstrapper;
        }

        public Browser Browser
        {
            get => _browser;
        }
    }
}
