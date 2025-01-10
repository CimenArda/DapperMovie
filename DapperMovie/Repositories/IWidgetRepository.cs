using Microsoft.Extensions.Hosting;

namespace DapperMovie.Repositories
{
    public interface IWidgetRepository
    {

        Task<int> GetAllMovieCount();
        Task<long> GetAllMovieBudget();
        Task<string> GetMostPopularMovieTitle();
        Task<string> GetHighestRatedMovieTitle();
        Task<string> GetMostVotedMovieTitle();
        Task<string> GetMostRevenueMovieTitleYear2019();
        Task<string> GetLongestMovieTitle();
        Task<string> GetMostProducedMovieGenre();
        Task<int> GetFilmCountByYear2024();

        Task<string> GetMostSpokenLanguage();

        Task<string> MostProducingFilmCompany();
    }
}
