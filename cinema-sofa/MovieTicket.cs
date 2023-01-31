using System;
namespace cinema_sofa
{
    public class MovieTicket
    {
        private MovieScreening _movieScreening;
        private int _rowNr;
        private int _seatNr;
        private bool _isPremium;

        public MovieTicket(
            MovieScreening movieScreening,
            bool isPremiumReservation,
            int seatRow,
            int SeatNr
        )
        {
            _movieScreening = movieScreening;
            _isPremium = isPremiumReservation;
            _rowNr = seatRow;
            _seatNr = SeatNr;
        }

        public bool isPremiumTicket()
        {
            return _isPremium;
        }

        public double getPrice()
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

