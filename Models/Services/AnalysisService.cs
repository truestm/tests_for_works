using Biogenom_test.Models.Dto;
using Biogenom_test.Models.Dto.Converters;
using Microsoft.EntityFrameworkCore;

namespace Biogenom_test.Models.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly AppDbContext _context;
        private readonly IUsersService _users;
        private readonly IQuestionnairesService _questionnaires;

        public AnalysisService(AppDbContext context, IUsersService users, IQuestionnairesService questionnaires)
        {
            _context = context;
            _users = users;
            _questionnaires = questionnaires;
        }

        public async Task<AnalysisResultDto> Analyze(int userId)
        {
            return new AnalysisResultDto();
        }
    }
}
