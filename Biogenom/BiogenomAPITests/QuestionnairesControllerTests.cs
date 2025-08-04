using BiogenomAPI.Models;
using BiogenomAPI.Models.Dto;
using BiogenomAPITests;
using System.Net;
using Xunit;

namespace Tests
{
    [Collection("Integration")]
    public class QuestionnairesControllerTests : IntegrationTestBase
    {
        [Fact]
        public async Task Create_Update()
        {
            #region Create

            var user = await FromContentJsonAsync<UserResultDto>(
                await Client.PutAsync("/api/users/update/0",
                    ToContentJson(new UserDto
                        (
                            new DateOnly(2000, 1, 1),
                            70,
                            Gender.Male,
                            Lifestyle.Active
                        )
                    )
                )
            );

            Assert.NotEqual(0, user?.UserId);

            {
                var response = await Client.PutAsync($"/api/questionnaires/update/{user?.UserId}",
                    ToContentJson(new QuestionnaireDto
                        (
                            null,
                            new ConsumptionDto[] 
                            {
                                new ConsumptionDto(100500, 1, 100),
                                new ConsumptionDto(1, 1, 100),
                                new ConsumptionDto(2, 2, 200),
                                new ConsumptionDto(3, 3, 300)
                            }
                        )
                    )
                );

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

            {
                var questionnaire = await FromContentJsonAsync<QuestionnaireDto>(await Client.GetAsync($"/api/questionnaires/{user?.UserId}"));

                Assert.Equal(questionnaire?.Consumptions,
                    new ConsumptionDto[]
                    {
                        new ConsumptionDto(1, 1, 100),
                        new ConsumptionDto(2, 2, 200),
                        new ConsumptionDto(3, 3, 300)
                    });
            }

            #endregion

            #region Update
            
            {
                var response = await Client.PutAsync($"/api/questionnaires/update/{user?.UserId}",
                    ToContentJson(new QuestionnaireDto
                        (
                            null,
                            new ConsumptionDto[]
                            {
                                new ConsumptionDto(1, 1, 101),
                                new ConsumptionDto(3, 3, 303),
                                new ConsumptionDto(100500, 1, 100),
                            }
                        )
                    )
                );
            }

            {
                var questionnaire = await FromContentJsonAsync<QuestionnaireDto>(await Client.GetAsync($"/api/questionnaires/{user?.UserId}"));

                Assert.Equal(questionnaire?.Consumptions,
                    new ConsumptionDto[]
                    {
                        new ConsumptionDto(1, 1, 101),
                        new ConsumptionDto(3, 3, 303)
                    });
            }

            #endregion
        }
    }
}