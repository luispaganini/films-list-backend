using FilmsList.Domain.Validation;

namespace FilmsList.Domain.Entities
{
    public class Movie : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImdbId { get; private set; }
        public int Score { get; private set; }
        public string Trailer { get; private set; }
        public string Poster { get; private set; }
        public string Backdrop { get; private set; }
        public int? PriorityLevel { get; private set; } = 1;

        public Movie(
            string title, 
            string description, 
            string imdbId, 
            int score, 
            string trailer, 
            string poster, 
            string backdrop, 
            int? priorityLevel)
        {
            Title = title;
            Description = description;
            ImdbId = imdbId;
            Score = score;
            Trailer = trailer;
            Poster = poster;
            Backdrop = backdrop;
            PriorityLevel = priorityLevel;
            ValidateDomain(title, description, imdbId, score, trailer, poster, backdrop, priorityLevel);


        }
        public void Update(
            string title, 
            string description, 
            string imdbId,
            int score, 
            string trailer, 
            string poster, 
            string backdrop, 
            int priorityLevel)
        {
            ValidateDomain(title, description, imdbId, score, trailer, poster, backdrop, priorityLevel);
        }

        public bool ValidateMovie()
        {
            try 
            {
                ValidateDomain(Title, Description, ImdbId, Score, Trailer, Poster, Backdrop, PriorityLevel);
            } 
            catch(DomainExceptionValidation) 
            {
                return false;
            }
            return true;
        }

        private void ValidateDomain(
            string title, 
            string description, 
            string imdbId,
            int score, 
            string trailer, 
            string poster, 
            string backdrop, 
            int? priorityLevel)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title),
                "Invalid title. Title is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(imdbId),
                "Invalid IMDBid. IMDBid is required");
            DomainExceptionValidation.When(score < 0 || score > 100,
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
            Score = score;
            Trailer = trailer;
            Poster = poster;
            Backdrop = backdrop;
            PriorityLevel = priorityLevel;
        }
    }
}