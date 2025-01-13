using DapperMovie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DefaultViewComponents
{
    public class _DefaultBarChartComponentPartial : ViewComponent
    {
        private readonly IChartRepository _repository;

        public _DefaultBarChartComponentPartial(IChartRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topMovies = await _repository.GetTopMoviesByVoteCount();

            // Chart.js için uygun format
            var barChartData = new
            {
                Labels = topMovies.Select(x => x.Title).ToArray(),
                Data = topMovies.Select(x => x.vote_average).ToArray(),
                Votes = topMovies.Select(x => x.vote_count).ToArray()
            };

            return View(barChartData);
        }
    }
}
