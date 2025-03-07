using CareerMate.EndPoints.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace FileSource.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json", "multipart/form-data")]
    public class BaseController : ControllerBase
    {
        protected ActionResult ToActionResult(BaseResponse response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
