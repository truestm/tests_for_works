using Biogenom_test.Models.Dto;

namespace Biogenom_test.Models.Services
{
    public interface IUsersService
    {
        Task<User> GetAsync(int userId);
        Task<User> UpdateAsync(int userId, UserDto dto);
    }
}
