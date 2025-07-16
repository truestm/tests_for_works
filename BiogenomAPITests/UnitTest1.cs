using System.Net;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Tests
{
    public class UsersControllerTests : IntegrationTestBase
    {
        public UsersControllerTests(CustomWebApplicationFactory<BiogenomAPI.Program> factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task CreateUser_ReturnsCreatedResponse()
        {
            // Arrange
            var newUser = new
            {
                Name = "Test User",
                Email = "test@example.com"
            };
            var content = new StringContent(
                JsonSerializer.Serialize(newUser),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await _client.PostAsync("/api/users", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            Assert.Contains("Test User", responseString);
        }
    }
}