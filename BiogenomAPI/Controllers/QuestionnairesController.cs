using BiogenomAPI.Helpers;
using BiogenomAPI.Models.Dto;
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
