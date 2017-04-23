using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.TinyIoc;
using Cards.API.BusinessLogic.Services;
using Cards.API.BusinessLogic.Services.Interfaces;
using System;
using Cards.API.BusinessLogic.Settings;
using Cards.Data;
using Nancy.Configuration;

namespace Cards.API
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly IApplicationSettings _applicationSettings;
        private readonly IServiceProvider _serviceProvider;

        public Bootstrapper()
        {
        }

        public Bootstrapper(IApplicationSettings applicationSettings, IServiceProvider serviceProvider)
        {
            _applicationSettings = applicationSettings;
            _serviceProvider = serviceProvider;
        }

        public override void Configure(INancyEnvironment environment)
        {
            base.Configure(environment);

            environment.Tracing(true, true);            
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(_applicationSettings);
            container.Register(_serviceProvider.GetService<ILoggerFactory>());

            container.Register<IVersionService, VersionService>();
            container.Register<ICardsRepository, CardsRepository>();
            container.Register<ICardsContext, GreekCardsContext>();
        }
    }
}
