using FilmsList.Domain.Validation;

namespace FilmsList.Domain.Entities
{
    public class Movie : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImdbId { get; private set; }
        public int RatingMovie { get; private set; }
        public string Trailer { get; private set; }
        public string Poster { get; private set; }
        public string Backdrop { get; private set; }
        public int PriorityLevel { get; private set; }

        public Movie(
            string title, 
            string description, 
            string imdbId, 
            int ratingMovie, 
            string trailer, 
            string poster, 
            string backdrop, 
            int priorityLevel)
        {
            Title = title;
            Description = description;
            ImdbId = imdbId;
            RatingMovie = ratingMovie;
            Trailer = trailer;
            Poster = poster;
            Backdrop = backdrop;
            PriorityLevel = priorityLevel;

        }
        public void Update(
            string title, 
            string description, 
            string imdbId,
            int ratingMovie, 
            string trailer, 
            string poster, 
            string backdrop, 
            int priorityLevel)
        {
            ValidateDomain(title, description, imdbId, ratingMovie, trailer, poster, backdrop, priorityLevel);
        }

        private void ValidateDomain(
            string title, 
            string description, 
            string imdbId,
            int ratingMovie, 
            string trailer, 
            string poster, 
            string backdrop, 
            int priorityLevel)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title),
                "Invalid title. Title is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(imdbId),
                "Invalid IMDBid. IMDBid is required");
            DomainExceptionValidation.When(ratingMovie < 0 || ratingMovie > 100,
                "Invalid rating movie value. Rating Movie is between 0 and 100");
            DomainExceptionValidation.When(string.IsNullOrEmpty(trailer),
                "Invalid trailer. Trailer is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(poster),
                "Invalid poster. Poster is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(backdrop),
                "Invalid backdrop. Backdrop is required");
            DomainExceptionValidation.When(priorityLevel < 1 || priorityLevel > 3,
                "Invalid Priority Level value. Priority Level is between 1 and 3");
            
            Title = title;
            Description = description;
            ImdbId = imdbId;
            RatingMovie = ratingMovie;
            Trailer = trailer;
            Poster = poster;
            Backdrop = backdrop;
            PriorityLevel = priorityLevel;
        }

    }
}