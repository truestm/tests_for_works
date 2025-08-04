using BiogenomAPI.Helpers;
using BiogenomAPI.Models.Dto;
using BiogenomAPI.Models.Dto.Converters;
using BiogenomAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> Get(int userId)
        {
            try
            {
                var user = await _service.GetAsync(userId);
                return Ok(user.ToDto());
            }
            catch (Exception ex)
            {
                return ex.ToActionResult(this);
            }
        }

        [HttpPut("update/{userId}")]
        public async Task<ActionResult<UserResultDto>> Update(int userId, [FromBody] UserDto dto)
        {
            try
            {
                var user = await _service.UpdateAsync(userId, dto);
                return Ok(new UserResultDto(user.Id, user.ToDto()));
            }
            catch (Exception ex)
            {
                return ex.ToActionResult(this);
            }
        }
    }
}
