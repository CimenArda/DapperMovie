using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DashboardLayoutViewComponents
{
    public class _DashboardLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
