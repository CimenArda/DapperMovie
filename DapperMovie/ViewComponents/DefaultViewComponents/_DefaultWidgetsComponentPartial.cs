using DapperMovie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DefaultViewComponents
{
    public class _DefaultWidgetsComponentPartial : ViewComponent
    {
        private readonly IWidgetRepository _widgetRepository;

        public _DefaultWidgetsComponentPartial(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var highestMovie = await _widgetRepository.GetHighestRatedMovieTitle();
            ViewBag.highestMovie = highestMovie;

            var mostVotedMovie = await _widgetRepository.GetMostVotedMovieTitle();
            ViewBag.mostVotedMovie = mostVotedMovie;

            var mostRevenue = await _widgetRepository.GetMostRevenueMovieTitleYear2019();
            ViewBag.mostRevenue = mostRevenue;

            var longestMovie = await _widgetRepository.GetLongestMovieTitle();
            ViewBag.longestMovie = longestMovie;

            var mostProducedMovieGenre = await _widgetRepository.GetMostProducedMovieGenre();
            ViewBag.mostProducedMovieGenre = mostProducedMovieGenre;


            var filmCountByYear2024 = await _widgetRepository.GetFilmCountByYear2024();
            ViewBag.filmCountByYear2024= filmCountByYear2024;

            var mostSpokenLanguages = await _widgetRepository.GetMostSpokenLanguage();
            ViewBag.mostSpokenLanguages= mostSpokenLanguages;


            var mostProducingFilmCompany = await _widgetRepository.MostProducingFilmCompany();
            ViewBag.mostProducingFilmCompany= mostProducingFilmCompany;
            return View();
        }
    }
}
