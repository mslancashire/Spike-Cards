using Nancy;
using System;
using Cards.API.BusinessLogic.Services.Interfaces;


namespace Cards.API.Modules
{
    public class MainModule : NancyModule
    {
        private readonly IVersionService _versionService;

        public MainModule(IVersionService versionService)
        {
            _versionService = versionService;

            Get("/", args =>
            {
                var model = new
                {
                    app = _versionService.GetApplicationName(),
                    version = _versionService.GetApplicationVersion(),
                    time = DateTime.Now
                };
            
                return View["Index", model];
            
            });
            
        }
    }
}
