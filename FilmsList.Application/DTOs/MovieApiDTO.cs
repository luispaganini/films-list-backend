using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FilmsList.Application.DTOs
{
    public class MovieApiDTO
    {
        [Required(ErrorMessage = "The imdbId is required")]
        [DisplayName("ImdbId")]
        public string ImdbId { get; set; }
        
        [Required(ErrorMessage = "The title is required")]
        [MinLength(3)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description is required")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The rating movie is required")]
        [Range(0, 100)]
        [DisplayName("Score")]
        public int Score { get; set; }

        [Required(ErrorMessage = "The trailer is required")]
        [DisplayName("Trailer")]
        public string Trailer { get; set; }

        [Required(ErrorMessage = "The poster is required")]
        [DisplayName("Poster")]
        public string Poster { get; set; }

        [Required(ErrorMessage = "The backdrop is required")]
        [DisplayName("Backdrop")]
        public string Backdrop { get; set; }

        [Required(ErrorMessage = "The response is required")]
        [DisplayName("Response")]
        public bool Response { get; set; }
    }
}