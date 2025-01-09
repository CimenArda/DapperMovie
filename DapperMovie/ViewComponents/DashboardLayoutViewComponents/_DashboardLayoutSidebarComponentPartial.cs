using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DashboardLayoutViewComponents
{
    public class _DashboardLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
