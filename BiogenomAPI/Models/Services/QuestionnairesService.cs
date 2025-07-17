using BiogenomAPI.Models.Dto;
using BiogenomAPI.Models.Dto.Converters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<List<Consumption>> GetConsumptionsAsync(int userId)
        {
            return await _context.Consumptions.Where(consumption => consumption.UserId == userId).ToListAsync();
        }

        public async Task UpdateAsync(int userId, QuestionnaireDto dto)
        {
            var user = dto?.Owner?.User != null ?
                await _users.UpdateAsync(userId, dto.Owner.User) :
                await _users.GetAsync(userId);

            if (dto?.Consumptions != null)
            {
                var existingProducts = await _context.Products.ToDictionaryAsync(x => x.Id, x => x.Name);

                var consumptionProductsId = dto.Consumptions.Select(x => x.ProductId).ToHashSet();

                var existingConsumptions = await _context.Consumptions
                      .Where(x => x.UserId == userId && consumptionProductsId.Contains(x.ProductId))
                      .ToDictionaryAsync(c => c.ProductId);

                var newConsumptions = new List<Consumption>();

                foreach (var consumption in dto.Consumptions.Where(x => existingProducts.ContainsKey(x.ProductId)))
                {
                    if (existingConsumptions.TryGetValue(consumption.ProductId, out var existing))
                        consumption.ToDb(existing);
                    else
                        newConsumptions.Add(consumption.ToDb(userId));
                }

                await _context.Consumptions.AddRangeAsync(newConsumptions);

                await _context.Consumptions
                    .Where(x => x.UserId == userId && !consumptionProductsId.Contains(x.ProductId))
                    .ExecuteDeleteAsync();

                await _context.SaveChangesAsync();
            }
        }
    }
}
