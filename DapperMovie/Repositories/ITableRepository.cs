using DapperMovie.Models;

namespace DapperMovie.Repositories
{
    public interface ITableRepository
    {
        Task<List<Top10MovieListViewModel>> GetTop10MovieList();
        Task<List<Top3LowestBudgetHighestVotesMovieViewModel>> GetTop3LowestBudgetHighestVotesMovies();
        Task<List<Top10CountriesByFilmCountViewModel>> GetTop10CountriesByFilmCount();
    }
}
