using Biogenom_test.Models.Dto;
using Biogenom_test.Models.Dto.Converters;
using Microsoft.EntityFrameworkCore;

namespace Biogenom_test.Models.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user != null ? user : throw new KeyNotFoundException("User not found");
        }

        public async Task<User> AddAsync(UserDto dto)
        {
            var user = await _context.Users.AddAsync(dto.ToDb());

            await _context.SaveChangesAsync();

            return user.Entity;
        }

        public async Task<User> UpdateAsync(int userId, UserDto dto)
        {
            if (userId == 0)
            {
                return await AddAsync(dto);
            }
            else
            {
                var user = await GetAsync(userId);

                dto.ToDb(user);
                
                await _context.SaveChangesAsync();

                return user;
            }
        }
    }
}
