using Biogenom_test.Models.Dto;

namespace Biogenom_test.Models.Services
{
    public interface IAnalysisService
    {
        Task Update(int userId, QuestionnaireDto dto);
        Task<AnalysisResultDto> Analyze(int userId);
    }
}
