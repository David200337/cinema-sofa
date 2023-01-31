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

        public double PetPricePerSeat()
        {
            // TODO: Implement
            return 0.0;
        }

        public override string ToString()
        {
            // TODO: Implement
            return "";
        }
    }
}

