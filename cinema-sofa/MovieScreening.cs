using System;
namespace cinema_sofa
{
    public class MovieScreening
    {
        private Movie _movie;
        private DateTime _dateAndTime;
        private double _pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            _movie = movie;
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
        }

        public string GetMovieTitle() {
            return _movie.GetTitle();
        }

        public DateTime DateAndTime()
        {
            return _dateAndTime;
        }

        public double PetPricePerSeat()
        {
            return _pricePerSeat;
        }

        public override string ToString()
        {
            return $"Movie: {_movie.ToString()}{Environment.NewLine}Price per seat: {_pricePerSeat}{Environment.NewLine}Screening date and time: {_dateAndTime.ToLocalTime().ToShortDateString()}";
        }
    }
}

