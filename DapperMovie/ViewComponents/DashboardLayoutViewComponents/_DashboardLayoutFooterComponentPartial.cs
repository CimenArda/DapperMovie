using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DashboardLayoutViewComponents
{
    public class _DashboardLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
