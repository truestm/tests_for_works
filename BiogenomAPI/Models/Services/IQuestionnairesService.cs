using BiogenomAPI.Models.Dto;

namespace BiogenomAPI.Models.Services
{
    public interface IQuestionnairesService
    {
        Task UpdateAsync(int userId, QuestionnaireDto dto);
    }
}
