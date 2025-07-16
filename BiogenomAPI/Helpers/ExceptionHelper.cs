using Microsoft.AspNetCore.Mvc;

namespace BiogenomAPI.Helpers
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
