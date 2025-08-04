using BiogenomAPI.Helpers;
using BiogenomAPI.Models.Dto;
using BiogenomAPI.Models.Dto.Converters;
using BiogenomAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionnairesController : ControllerBase
    {
        private readonly IQuestionnairesService _service;

        public QuestionnairesController(IQuestionnairesService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<QuestionnaireDto>> Get(int userId)
        {
            try
            {
                var consumptions = await _service.GetConsumptionsAsync(userId);
                return Ok(new QuestionnaireDto(new UserResultDto(userId, null), consumptions.ToDto()));
            }
            catch (Exception ex)
            {
                return ex.ToActionResult(this);
            }
        }

        [HttpPut("update/{userId}")]
        public async Task<ActionResult> Update(int userId, [FromBody] QuestionnaireDto dto)
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
