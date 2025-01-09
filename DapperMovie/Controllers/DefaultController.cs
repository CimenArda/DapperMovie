using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
