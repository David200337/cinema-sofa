using System.Text.Json.Serialization;

namespace Cinema
{
    public class Movie
    {
        private readonly List<MovieScreening> _screenings;

        [JsonInclude, JsonPropertyName("Title")]
        public string _title { get; private set; }

        public Movie(string title)
        {
            _screenings = new List<MovieScreening>();
            _title = title;
        }

        public void AddScreening(MovieScreening screening)
        {
            _screenings.Add(screening);
        }

        public override string ToString()
        {
            return $"Title: {_title}";
        }
    }
}

