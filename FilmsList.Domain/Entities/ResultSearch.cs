namespace FilmsList.Domain.Entities
{
    public class ResultSearch
    {
        public string ImdbId { get; set; }
        public string? Title { get; set; }
        public int? Score { get; set; }
        public string? Type { get; set; }
        
    }
}