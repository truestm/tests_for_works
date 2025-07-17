using AngleSharp.Io;
using BiogenomAPI;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace BiogenomAPITests
{
    public class IntegrationTestBase
    {
        protected readonly CustomWebApplicationFactory<Program> Factory;
        protected readonly HttpClient Client;

        protected static StringContent ToContentJson<T>(T obj) =>
            new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

        protected static async Task<T?> FromContentJsonAsync<T>(HttpResponseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };
            return await JsonSerializer.DeserializeAsync<T>(await message.Content.ReadAsStreamAsync(), options);
        }

        protected IntegrationTestBase()
        {
            Factory = new CustomWebApplicationFactory<Program>();
            Client = Factory.CreateClient();
        }
    }
}
