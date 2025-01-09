using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DashboardLayoutViewComponents
{
    public class _DashboardLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
