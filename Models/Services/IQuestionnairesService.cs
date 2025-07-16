using Biogenom_test.Models.Dto;

namespace Biogenom_test.Models.Services
{
    public interface IQuestionnairesService
    {
        Task UpdateAsync(int userId, QuestionnaireDto dto);
    }
}
