using Biogenom_test.Models.Dto;

namespace Biogenom_test.Models.Services
{
    public interface IAnalysisService
    {
        Task<AnalysisResultDto> Analyze(int userId);
    }
}
