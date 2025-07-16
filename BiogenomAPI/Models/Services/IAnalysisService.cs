using BiogenomAPI.Models.Dto;

namespace BiogenomAPI.Models.Services
{
    public interface IAnalysisService
    {
        Task<AnalysisResultDto> Analyze(int userId);
    }
}
