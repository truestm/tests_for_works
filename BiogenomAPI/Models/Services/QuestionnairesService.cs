using BiogenomAPI.Models.Dto;
using BiogenomAPI.Models.Dto.Converters;
using Microsoft.EntityFrameworkCore;

namespace BiogenomAPI.Models.Services
{
    public class QuestionnairesService : IQuestionnairesService
    {
        private readonly AppDbContext _context;
        private readonly IUsersService _users;

        public QuestionnairesService(AppDbContext context, IUsersService users)
        {
            _context = context;
            _users = users;
        }

        public async Task UpdateAsync(int userId, QuestionnaireDto dto)
        {
            var user = await _users.UpdateAsync(userId, dto.User);

            user.Consumptions.Clear();

            foreach (var consumption in dto.Consumptions)
            {
                user.Consumptions.Add(new Consumption
                {
                    ProductId = consumption.ProductId,
                    TimesPerMonth = consumption.TimesPerMonth,
                    TypicalPortionGrams = consumption.TypicalPortionGrams
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
