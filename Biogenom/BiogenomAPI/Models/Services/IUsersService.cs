using BiogenomAPI.Models.Dto;

namespace BiogenomAPI.Models.Services
{
    public interface IUsersService
    {
        Task<User> GetAsync(int userId);
        Task<User> UpdateAsync(int userId, UserDto dto);
    }
}
