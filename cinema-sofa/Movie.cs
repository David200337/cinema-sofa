using System.Text.Json.Serialization;

namespace cinema_sofa
{
    public class Movie
    {
        private List<MovieScreening> _screenings;

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

        public string GetTitle()
        {
            return _title;
        }

        public override string ToString()
        {
            return $"{_title}";
        }
    }
}

