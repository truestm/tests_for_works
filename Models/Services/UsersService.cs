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

        public async Task<UserResultDto> Update(int userId, UserDto dto)
        {
            if (userId == 0)
            {
                var user = await _context.Users.AddAsync(dto.ToDb());
                return new UserResultDto(user.Entity.Id, user.Entity.ToDto());
            }
            else
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == userId);
                
                if (user == null)
                    throw new KeyNotFoundException("User not found");

                dto.ToDb(user);
                
                await _context.SaveChangesAsync();

                return new UserResultDto(user.Id, user.ToDto());
            }
        }
    }
}
