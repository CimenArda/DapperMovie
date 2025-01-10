
using Dapper;
using DapperMovie.Context;
using System.Data.SqlClient;

namespace DapperMovie.Repositories
{
    public class WidgetRepository : IWidgetRepository
    {
        private readonly MovieContext _movieContext;
        public WidgetRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<long> GetAllMovieBudget()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                const string sqlQuery = "SELECT SUM(CAST(Budget AS BIGINT)) FROM TMDB_movie_dataset_v11";
                var totalBudget = await connection.ExecuteScalarAsync<long>(sqlQuery);
                return totalBudget;
            }
        }

        public async Task<int> GetAllMovieCount()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                const string sqlQuery = "SELECT COUNT(*) FROM TMDB_movie_dataset_v11";
                var count = await connection.ExecuteScalarAsync<int>(sqlQuery);
                return count;
            }

        }

        public async Task<int> GetFilmCountByYear2024()
        {
              using (var connection = _movieContext.CreateConnection())
            {
                const string sqlQuery = "  SELECT COUNT(*)  FROM TMDB_movie_dataset_v11  WHERE YEAR(release_date) = 2024";
                var count = await connection.ExecuteScalarAsync<int>(sqlQuery);
                return count;
            }
        }

        public async Task<string> GetHighestRatedMovieTitle()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                var sqlQuery = "SELECT TOP 1 title FROM TMDB_movie_dataset_v11 ORDER BY vote_average DESC";
                return await connection.ExecuteScalarAsync<string>(sqlQuery);
            }
        }

        public async Task<string> GetLongestMovieTitle()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                var sqlQuery = "SELECT TOP 1 title FROM TMDB_movie_dataset_v11 ORDER BY runtime DESC";
                return await connection.ExecuteScalarAsync<string>(sqlQuery);
            }
        }

        public async Task<string> GetMostPopularMovieTitle()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                var sqlQuery = "SELECT TOP 1 Title From TMDB_movie_dataset_v11  ORDER BY popularity DESC";
                return await connection.ExecuteScalarAsync<string>(sqlQuery);
            }
        }

        public async Task<string> GetMostProducedMovieGenre()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                var query = @"
                       -- En fazla tekrar eden türü (genre) alır
                        SELECT TOP 1 
                            genres
                        FROM 
                        (SELECT value AS genres  -- genres sütunundaki virgülle ayrılmış türleri ayırır
                         FROM TMDB_movie_dataset_v11  -- TMDB_movie_dataset_v11 tablosu
                             CROSS APPLY STRING_SPLIT(genres, ',')  -- genres değerlerini virgülle ayırır
                        ) AS SplitGenres  -- İç sorgunun adlandırılması
                    GROUP BY 
                        genres  -- Türlere göre gruplama yapar
                    ORDER BY 
                        COUNT(*) DESC;  -- En fazla tekrar eden türü sıralar
        ";

                var result = await connection.QueryFirstOrDefaultAsync<string>(query);

                return result;
            }
        }


        public async Task<string> GetMostRevenueMovieTitleYear2019()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                var sqlQuery = "SELECT TOP 1 Title FROM TMDB_movie_dataset_v11 WHERE YEAR(release_date) = 2010 ORDER BY Revenue DESC;";
                return await connection.ExecuteScalarAsync<string>(sqlQuery);
            }
        }

        public async Task<string> GetMostSpokenLanguage()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                var query = @"
                     SELECT TOP 1
                    language AS MostSpokenLanguage
                FROM (
                    SELECT value AS language
                    FROM TMDB_movie_dataset_v11
                    CROSS APPLY STRING_SPLIT(spoken_languages, ',')
                ) AS languages
                GROUP BY language
                ORDER BY COUNT(*) DESC
        ";

                var result = await connection.QueryFirstOrDefaultAsync<string>(query);

                return result;
            }
        }

        public async Task<string> GetMostVotedMovieTitle()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                var sqlQuery = "SELECT TOP 1 Title From TMDB_movie_dataset_v11  ORDER BY vote_count DESC";
                return await connection.ExecuteScalarAsync<string>(sqlQuery);
            }
        }

        public async Task<string> MostProducingFilmCompany()
        {
            using (var connection = _movieContext.CreateConnection())
            {
                var query = @"
                     WITH CompanyFilmCount AS (
                    SELECT
                        company,
                        COUNT(*) AS FilmCount,
                        ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC) AS RowNum
                    FROM (
                        SELECT value AS company
                        FROM TMDB_movie_dataset_v11
                        CROSS APPLY STRING_SPLIT(production_companies, ',')
                    ) AS companies
                    GROUP BY company
                )
                SELECT company AS SecondMostFrequentCompany
                FROM CompanyFilmCount
                WHERE RowNum = 2
        ";

                var result = await connection.QueryFirstOrDefaultAsync<string>(query);

                return result;
            }
        }
    }

}
