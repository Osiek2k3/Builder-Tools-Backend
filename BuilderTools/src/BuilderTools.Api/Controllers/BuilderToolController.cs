using Microsoft.AspNetCore.Mvc;

namespace BuilderTools.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuilderToolController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
