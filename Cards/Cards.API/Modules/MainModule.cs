using Nancy;
using System;
using Cards.API.BusinessLogic.Services.Interfaces;


namespace Cards.API.Modules
{
    public class MainModule : NancyModule
    {
        private readonly IVersionService versionService;

        public MainModule(IVersionService versionServiceSvc)
        {
            versionService = versionServiceSvc;

            Get("/", args =>
            {
                var model = new
                {
                    app = versionService.GetApplicationName(),
                    version = versionService.GetApplicationVersion(),
                    time = DateTime.Now
                };
            
                return View["Index", model];
            
            });
            
        }
    }
}
