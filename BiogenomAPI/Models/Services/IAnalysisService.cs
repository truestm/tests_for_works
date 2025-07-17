using BiogenomAPI.Models.Dto;

namespace BiogenomAPI.Models.Services
{
    public interface IAnalysisService
    {
        Task<List<NutrientAnalysisResult>> GetConsumptionsAsync(User user);
    }
}
