using Microsoft.AspNetCore.Mvc;

namespace ChatterBot.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return Ok("Hello World!");
        }
    }
}