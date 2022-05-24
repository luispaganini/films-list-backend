namespace FilmsList.Domain.Entities
{
    public class ErrorMovie
    {
        public bool Response { get; private set; }
        public string Error { get; private set; }

        public ErrorMovie(bool response, string error)
        {
            this.Response = response;
            this.Error = error;
        }

        public bool isInvalid() {
            if (Response == false)
                return true;

            return false;
        }
    }
}