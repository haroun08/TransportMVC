using Microsoft.AspNetCore.Mvc;

namespace TransportMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
