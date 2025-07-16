using Biogenom_test.Models.Dto;

namespace Biogenom_test.Models.Services
{
    public interface IUsersService
    {
        Task<UserResultDto> Update(int userId, UserDto dto);
    }
}
