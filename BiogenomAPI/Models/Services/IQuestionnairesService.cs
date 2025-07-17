using BiogenomAPI.Models.Dto;

namespace BiogenomAPI.Models.Services
{
    public interface IQuestionnairesService
    {
        Task<List<Consumption>> GetConsumptionsAsync(int userId);
        Task UpdateAsync(int userId, QuestionnaireDto dto);
    }
}
