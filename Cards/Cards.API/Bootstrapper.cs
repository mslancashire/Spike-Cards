using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.TinyIoc;
using Cards.API.BusinessLogic.Services;
using Cards.API.BusinessLogic.Services.Interfaces;
using System;


namespace Cards.API
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly IAppSettings appSettings;
        private readonly IServiceProvider serviceProvider;
        public Bootstrapper()
        {
        }

        public Bootstrapper(IAppSettings appSet, IServiceProvider serviceProv)
        {
            appSettings = appSet;
            serviceProvider = serviceProv;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(appSettings);
            container.Register(serviceProvider.GetService<ILoggerFactory>());

            container.Register<IVersionService, VersionService>();
        }

        
    }
}
