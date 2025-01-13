using Dapper;
using DapperMovie.Context;
using DapperMovie.Models;

namespace DapperMovie.Repositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly MovieContext _movieContext;
        public ChartRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GenreChartViewModel>> Get5MovieGenresForPieChart()
        {
            string query = @"
                SELECT TOP 5 genre, COUNT(*) AS MovieCount
                FROM (
                    SELECT value AS genre
                    FROM TMDB_movie_dataset_v11
                    CROSS APPLY STRING_SPLIT(genres, ',') 
                ) AS SplitGenres
                GROUP BY genre
                ORDER BY MovieCount DESC;
            ";

            using var connection = _movieContext.CreateConnection();
            var result = await connection.QueryAsync<GenreChartViewModel>(query);
            return result.ToList();
        }

        public async Task<List<BarChartViewModel>> GetTopMoviesByVoteCount()
        {
            string query = @"
                          SELECT TOP 5 title, vote_average, vote_count 
                FROM  TMDB_movie_dataset_v11
                ORDER BY vote_count DESC;

                            ";
            using var connection = _movieContext.CreateConnection();
            var result = await connection.QueryAsync<BarChartViewModel>(query);

            return result.ToList();
        }
    }
}
