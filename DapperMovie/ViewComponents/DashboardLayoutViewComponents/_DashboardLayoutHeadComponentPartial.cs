using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DashboardLayoutViewComponents
{
    public class _DashboardLayoutHeadComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
