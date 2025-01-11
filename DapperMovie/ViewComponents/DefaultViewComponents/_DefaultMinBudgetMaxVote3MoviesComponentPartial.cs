using DapperMovie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DefaultViewComponents
{
    public class _DefaultMinBudgetMaxVote3MoviesComponentPartial : ViewComponent
    {
        private readonly ITableRepository _tableRepository;

        public _DefaultMinBudgetMaxVote3MoviesComponentPartial(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _tableRepository.GetTop3LowestBudgetHighestVotesMovies();
            return View(values);
        }
    }
}
