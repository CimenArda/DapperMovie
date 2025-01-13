using DapperMovie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DefaultViewComponents
{
    public class _DefaultPieChartComponentPartial : ViewComponent
    {
        private readonly IChartRepository _repository;

        public _DefaultPieChartComponentPartial(IChartRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movieGenres = await _repository.Get5MovieGenresForPieChart();

            // Chart.js için uygun formatta veri
            var pieChartData = new
            {
                Labels = movieGenres.Select(x => x.Genre).ToArray(),
                Data = movieGenres.Select(x => x.MovieCount).ToArray(),
                BackgroundColor = new[] { "#FF6384", "#36A2EB", "#FFCE56", "#FF9F40", "#4BC0C0" }
            };

            return View(pieChartData);
        }
    }
}
