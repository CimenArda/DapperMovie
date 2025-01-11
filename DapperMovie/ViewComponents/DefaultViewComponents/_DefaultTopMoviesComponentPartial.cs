using DapperMovie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperMovie.ViewComponents.DefaultViewComponents
{
    public class _DefaultTopMoviesComponentPartial : ViewComponent
    {
        private readonly ITableRepository _tableRepository;

        public _DefaultTopMoviesComponentPartial(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _tableRepository.GetTop10MovieList();
            return View(values);    
        }
    }
}
