using BiogenomAPI.Models;
using BiogenomAPI.Models.Dto;
using BiogenomAPITests;
using System.Net;
using Xunit;

namespace Tests
{
    [Collection("Integration")]
    public class AnalysisControllerTests : IntegrationTestBase
    {
        [Fact]
        public async Task Male_VeryActive_UpTo30()
        {
            #region Prepare user and questionnaire

            var user = await FromContentJsonAsync<UserResultDto>(
                await Client.PutAsync("/api/users/update/0",
                    ToContentJson(new UserDto
                        (
                            new DateOnly(2000, 1, 1),
                            70,
                            Gender.Male,
                            Lifestyle.VeryActive
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

            #endregion

            {
                var analysisResult = await FromContentJsonAsync<AnalysisResultDto>(await Client.GetAsync($"/api/analysis/{user?.UserId}"));

                Assert.NotNull(analysisResult);
                Assert.Equal(1, analysisResult.Deviations[0].NutrientId);
                Assert.Equal("Белки", analysisResult.Deviations[0].NutrientName);
                Assert.Equal(NutrientUnit.Gram, analysisResult.Deviations[0].Unit);
                Assert.Equal(1, analysisResult.Deviations[0].NormId);
                Assert.Equal("Норма белка для молодых активных мужчин", analysisResult.Deviations[0].NormDescription);
                Assert.Equal(0m, analysisResult.Deviations[0].DailyNorm);
                Assert.Equal(3m, analysisResult.Deviations[0].DailyNormWeight);
                Assert.Equal(7.24333m, analysisResult.Deviations[0].ActualAmount, 4);
                Assert.Equal(210.0m, analysisResult.Deviations[0].RecommendedAmount, 4);
            }
        }
    }
}