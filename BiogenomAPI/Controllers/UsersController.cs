using BiogenomAPI.Helpers;
using BiogenomAPI.Models.Dto;
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

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> Update(int userId, [FromBody] UserDto dto)
        {
            try
            {
                await _service.UpdateAsync(userId, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return ex.ToActionResult(this);
            }
        }
    }
}
