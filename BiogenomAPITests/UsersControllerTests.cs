using BiogenomAPI.Models.Dto;
using BiogenomAPI.Models;
using BiogenomAPITests;
using System.Net;
using Xunit;

namespace Tests
{
    public class UsersControllerTests : IntegrationTestBase
    {
        [Fact]
        public async Task Create_Read_Update()
        {
            UserResultDto? createResult;
            {
                var user = new UserDto(new DateOnly(2000, 1, 1), 70, Gender.Male, Lifestyle.Active);

                var response = await Client.PutAsync("/api/users/update/0", ToContentJson(user));

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                createResult = await FromContentJsonAsync<UserResultDto>(response);

                Assert.NotNull(createResult);
                Assert.NotEqual(0, createResult?.UserId);
                Assert.Equal(new DateOnly(2000, 1, 1), createResult?.User?.BirthDate);
                Assert.Equal(Gender.Male, createResult?.User?.Gender);
                Assert.Equal(Lifestyle.Active, createResult?.User?.Lifestyle);
            }

            {
                var response = await Client.GetAsync($"/api/users/{createResult?.UserId}");

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var result = await FromContentJsonAsync<UserDto>(response);

                Assert.NotNull(result);
                Assert.Equal(new DateOnly(2000, 1, 1), result?.BirthDate);
                Assert.Equal(Gender.Male, result?.Gender);
                Assert.Equal(Lifestyle.Active, result?.Lifestyle);
            }

            {
                var user = new UserDto(new DateOnly(2002, 2, 2), 72, Gender.Female, Lifestyle.Moderate);

                var response = await Client.PutAsync($"/api/users/update/{createResult?.UserId}", ToContentJson(user));

                // Assert
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var updateResult = await FromContentJsonAsync<UserResultDto>(response);

                Assert.NotNull(updateResult);
                Assert.Equal(updateResult?.UserId, createResult?.UserId);

                Assert.Equal(new DateOnly(2002, 2, 2), updateResult?.User?.BirthDate);
                Assert.Equal(Gender.Female, updateResult?.User?.Gender);
                Assert.Equal(Lifestyle.Moderate, updateResult?.User?.Lifestyle);
            }

            {
                var response = await Client.GetAsync($"/api/users/{createResult?.UserId}");

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var result = await FromContentJsonAsync<UserDto>(response);

                Assert.NotNull(result);
                Assert.Equal(new DateOnly(2002, 2, 2), result?.BirthDate);
                Assert.Equal(Gender.Female, result?.Gender);
                Assert.Equal(Lifestyle.Moderate, result?.Lifestyle);
            }
        }
    }
}