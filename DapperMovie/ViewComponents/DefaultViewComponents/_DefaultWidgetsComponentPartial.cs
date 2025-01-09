using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DefaultViewComponents
{
    public class _DefaultWidgetsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
