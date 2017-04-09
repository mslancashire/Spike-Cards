using Cards.API.BusinessLogic.Services.Interfaces;

namespace Cards.API.Services
{
    public class AppSettings : IAppSettings
    {
        public string Value1 { get; set; }

        public string Value2 { get; set; }

        public string Value3 { get; set; }
    }
}
