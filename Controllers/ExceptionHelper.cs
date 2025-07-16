using Microsoft.AspNetCore.Mvc;

namespace Biogenom_test.Controllers
{
    public static class ExceptionHelper
    {
        public static ActionResult ToActionResult(this Exception exception, ControllerBase controller)
        {
            return exception switch
            {
                KeyNotFoundException => controller.NotFound(exception.Message),
                _ => controller.StatusCode(500, new { Error = exception.Message })
            };
        }
    }
}
