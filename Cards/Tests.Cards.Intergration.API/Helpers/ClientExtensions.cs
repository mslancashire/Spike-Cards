using Newtonsoft.Json;

namespace Tests.Cards.Integration.API.Helpers;

internal static class ClientExtensions
{
    internal static async Task<T?> GetAs<T>(this HttpResponseMessage response)
    {
        var result = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(result);
    }
}
