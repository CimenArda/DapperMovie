using DapperMovie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DefaultViewComponents
{
    public class _DefaultTop10CountriesByFilmCountComponentPartial : ViewComponent
    {
        private readonly ITableRepository _tableRepository;

        public _DefaultTop10CountriesByFilmCountComponentPartial(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _tableRepository.GetTop10CountriesByFilmCount();
            return View(values);
        }
    }
}