using Nancy.Testing;
using Cards.API.Tests.TestHelpers;
using Xunit;

namespace Cards.API.Tests.Modules
{
    public class MainModuleTests : TestBase
    {
        [Fact(DisplayName = "VersionTest")]
        public void VersionTest()
        {
            var response = Browser.Get("/", with =>
            {
                with.HttpRequest();
            });            

            var info = response.Result.Body.AsString();

            Assert.False(string.IsNullOrEmpty(info));
        }
    }
}
