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

        public bool IsPremiumTicket()
        {
            return _isPremium;
        }

        public double GetPrice()
        {
            return _movieScreening.PetPricePerSeat();
        }

        public DateTime GetScreeningDateAndTime()
        {
            return _movieScreening.DateAndTime();
        }

        public override string ToString()
        {
            return $"Movie: {_movieScreening.GetMovieTitle()}{Environment.NewLine}Screening: {GetScreeningDateAndTime()}{Environment.NewLine}Premium: {(IsPremiumTicket() ? "Yes" : "No")}{Environment.NewLine}Price: {GetPrice()}";
        }
    }
}

