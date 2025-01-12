namespace DapperMovie.Models
{
    public class Top10CountriesByFilmCountViewModel
    {
        public string Country { get; set; } // SQL'deki "country" ile eşleşmeli
        public int film_count { get; set; }  // SQL'deki "film_count" ile eşleşmeli
    }
}
