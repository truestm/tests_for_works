using BiogenomAPI.Helpers;
using BiogenomAPI.Models.Dto;
using BiogenomAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _service;

        public AnalysisController(IAnalysisService service)
        {
            _service = service;
        }

        [HttpGet("analyze/{userId}")]
        public async Task<ActionResult<AnalysisResultDto>> Analyze(int userId)
        {
            try
            {
                var result = await _service.Analyze(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ex.ToActionResult(this);
            }
        }
    }
}
