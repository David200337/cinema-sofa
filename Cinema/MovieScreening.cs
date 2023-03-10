using System;
using System.Text.Json.Serialization;

namespace Cinema
{
    public class MovieScreening
    {
        [JsonInclude, JsonPropertyName("Movie")]
        public Movie _movie { get; private set; }

        [JsonInclude, JsonPropertyName("DateAndTime")]
        public DateTime _dateAndTime { get; private set; }

        [JsonInclude, JsonPropertyName("PricePerSeat")]
        public double _pricePerSeat { get; private set; }

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            _movie = movie;
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
        }

        public string GetMovieTitle()
        {
            return _movie._title;
        }

        public override string ToString()
        {
            return $"Movie: {_movie.ToString()}{Environment.NewLine}Price per seat: {_pricePerSeat}{Environment.NewLine}Screening date and time: {_dateAndTime.ToLocalTime().ToShortDateString()}";
        }
    }
}

