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

        [HttpPut("update/{userId}")]
        public async Task<ActionResult> Update(int userId, [FromBody] QuestionnaireDto dto)
        {
            try
            {
                await _service.Update(userId, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return ex.ToActionResult(this);
            }
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
