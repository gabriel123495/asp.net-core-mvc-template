using Microsoft.AspNetCore.Mvc;

namespace Minecraft.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
