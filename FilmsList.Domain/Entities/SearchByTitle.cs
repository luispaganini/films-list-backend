namespace FilmsList.Domain.Entities
{
    public class SearchByTitle
    {
        public IEnumerable<ResultSearch> Search { get; set; }
        public int Total { get; set; }
        public bool Response { get; set; }
    }
}