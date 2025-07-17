using BiogenomAPI.Models.Dto;
using BiogenomAPI.Models.Dto.Converters;
using Microsoft.EntityFrameworkCore;

namespace BiogenomAPI.Models.Services
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

        public async Task<List<NutrientAnalysisResult>> GetConsumptionsAsync(User user)
        {
            const int GENDER_MATCH_WEIGHT = 3;
            const int LIFESTYLE_MATCH_WEIGHT = 2;
            const int AGE_BOUND_WEIGHT = 1;

            var age = DateTime.Now.Year - user.BirthDate.Year;

            return await _context.Nutrients
                .Select(nutrient => new
                {
                    Nutrient = nutrient,
                    Norm = nutrient.Norms
                        .Where(n =>
                            (n.Gender == null || n.Gender == user.Gender) &&
                            (n.MinAge == null || age >= n.MinAge) &&
                            (n.MaxAge == null || age <= n.MaxAge) &&
                            (n.Lifestyle == null || n.Lifestyle == user.Lifestyle))
                        .OrderByDescending(n =>
                            (n.Gender == user.Gender ? GENDER_MATCH_WEIGHT : 0) +
                            (n.Lifestyle == user.Lifestyle ? LIFESTYLE_MATCH_WEIGHT : 0) +
                            (n.MinAge != null ? AGE_BOUND_WEIGHT : 0) +
                            (n.MaxAge != null ? AGE_BOUND_WEIGHT : 0))
                        .ThenBy(n => n.MinAge ?? 0)
                        .ThenBy(n => n.MaxAge ?? int.MaxValue)
                        .FirstOrDefault(),
                    TotalConsumed = nutrient.ProductContents
                        .Sum(pn => pn.Amount *
                            _context.Consumptions
                                .Where(c => c.UserId == user.Id && c.ProductId == pn.ProductId)
                                .Sum(c => c.TypicalPortionGrams / 100 * c.TimesPerMonth / 30))
                })
                .Where(x => x.Norm != null)
                .Select(x => new NutrientAnalysisResult
                {
                    Nutrient = x.Nutrient,
                    Norm = x.Norm!,
                    TotalConsumed = x.TotalConsumed,
                    DailyNorm = (x.Norm!.DailyNorm ?? 0) + (x.Norm.DailyNormWeight ?? 0) * user.Weight
                })
                .ToListAsync();
        }
    }
}
