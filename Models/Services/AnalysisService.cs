using Biogenom_test.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biogenom_test.Models.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly AppDbContext _context;

        public AnalysisService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Update(int userId, QuestionnaireDto dto)
        {
            var user = await _context.Users
                .Include(u => u.ProductConsumptions)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            user.BirthDate = dto.User.BirthDate;
            user.Weight = dto.User.Weight;
            user.Gender = dto.User.Gender;
            user.Lifestyle = dto.User.Lifestyle;

            user.ProductConsumptions.Clear();

            foreach (var pc in dto.ProductConsumptions)
            {
                user.ProductConsumptions.Add(new UserProductConsumption
                {
                    ProductId = pc.ProductId,
                    TimesPerMonth = pc.TimesPerMonth,
                    TypicalPortionGrams = pc.TypicalPortionGrams
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<AnalysisResultDto> Analyze(int userId)
        {
            return new AnalysisResultDto();
        }
    }
}
