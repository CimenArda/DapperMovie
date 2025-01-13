using DapperMovie.Models;

namespace DapperMovie.Repositories
{
    public interface IChartRepository
    {
       Task<List<BarChartViewModel>> GetTopMoviesByVoteCount();
       Task<List<GenreChartViewModel>> Get5MovieGenresForPieChart();

    }
}
