namespace FilmsList.Domain.Validation
{
    public class MovieNotFoundExceptionValidation : Exception
    {
        public MovieNotFoundExceptionValidation(string error) : base(error)
        { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                 throw new MovieNotFoundExceptionValidation(error);
        }
    }
}