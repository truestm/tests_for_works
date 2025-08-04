using BiogenomAPI.Helpers;
using BiogenomAPI.Models.Dto;
using BiogenomAPI.Models.Dto.Converters;
using BiogenomAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _service;
        private readonly IUsersService _users;

        public AnalysisController(IAnalysisService service, IUsersService users )
        {
            _service = service;
            _users = users;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<AnalysisResultDto>> Analyze(int userId)
        {
            try
            {
                var user = await _users.GetAsync(userId);
                var consumptions = await _service.GetConsumptionsAsync(user);

                return Ok(new AnalysisResultDto(new UserResultDto(user.Id, user.ToDto()), consumptions.ToDto()));
            }
            catch (Exception ex)
            {
                return ex.ToActionResult(this);
            }
        }
    }
}
