using Dapper;
using DapperMovie.Context;
using DapperMovie.Models;

namespace DapperMovie.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly MovieContext _movieContext;
        public TableRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<List<Top10MovieListViewModel>> GetTop10MovieList()
        {
            string query = @"
                            Select top 10 Title,genres,spoken_languages,budget,production_companies from TMDB_movie_dataset_v11
                            ";
            using var connection = _movieContext.CreateConnection();
            var result = await connection.QueryAsync<Top10MovieListViewModel>(query);

            return result.ToList();
        }

        public async Task<List<Top3LowestBudgetHighestVotesMovieViewModel>> GetTop3LowestBudgetHighestVotesMovies()
        {
            string query = @"
                           SELECT TOP 3 
                                Title,release_date,genres,poster_path,backdrop_path,overview
                                  FROM TMDB_movie_dataset_v11
                                WHERE Budget > 0 -- Bütçesi 0'dan büyük olan filmleri al
                            ORDER BY Budget ASC, vote_count DESC; -- Bütçeye göre artan, oya göre azalan sırayla sıralar

                            ";
            using var connection = _movieContext.CreateConnection();
            var result = await connection.QueryAsync<Top3LowestBudgetHighestVotesMovieViewModel>(query);

            return result.ToList();
        }
    }
}
