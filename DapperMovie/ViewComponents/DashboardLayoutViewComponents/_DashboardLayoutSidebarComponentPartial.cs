using DapperMovie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DashboardLayoutViewComponents
{
    public class _DashboardLayoutSidebarComponentPartial : ViewComponent
    {
        private readonly IWidgetRepository _widgetRepository;

        public _DashboardLayoutSidebarComponentPartial(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalMovies = await _widgetRepository.GetAllMovieCount();
            ViewBag.TotalMovies = totalMovies; // View'a veri taşıma

            var totalBudget = await _widgetRepository.GetAllMovieBudget();
            ViewBag.TotalBudget = string.Format("{0:N0}", totalBudget); 

            var mostpopularMovieTitle = await _widgetRepository.GetMostPopularMovieTitle();
            ViewBag.mostpopularmovieTitle = mostpopularMovieTitle;





            return View();
        }
    }
}
