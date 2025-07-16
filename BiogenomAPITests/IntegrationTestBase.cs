using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests
{
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<BiogenomAPI.Program>>
    {
        protected readonly HttpClient _client;
        protected readonly CustomWebApplicationFactory<BiogenomAPI.Program> _factory;

        public IntegrationTestBase(CustomWebApplicationFactory<BiogenomAPI.Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
