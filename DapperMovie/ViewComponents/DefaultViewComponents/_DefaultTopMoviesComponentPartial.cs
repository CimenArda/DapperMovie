using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DefaultViewComponents
{
    public class _DefaultTopMoviesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
