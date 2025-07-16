using Biogenom_test.Helpers;
using Biogenom_test.Models.Dto;
using Biogenom_test.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom_test.Controllers
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
