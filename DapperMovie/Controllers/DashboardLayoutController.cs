using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.Controllers
{
    public class DashboardLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
