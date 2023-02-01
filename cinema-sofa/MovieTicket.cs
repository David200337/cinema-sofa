using System;
using System.Text.Json.Serialization;

namespace cinema_sofa
{
    public class MovieTicket
    {
        [JsonInclude, JsonPropertyName("MovieScreening")]
        public MovieScreening _movieScreening { get; private set; }

        [JsonInclude, JsonPropertyName("RowNr")]
        public int _rowNr { get; private set; }

        [JsonInclude, JsonPropertyName("SeatNr")]
        public int _seatNr { get; private set; }

        [JsonInclude, JsonPropertyName("PremiumTicket")]
        public bool _isPremium { get; private set; }

        [JsonInclude, JsonPropertyName("StudentTicket")]
        public bool _isStudent { get; private set; }

        public MovieTicket(
            MovieScreening movieScreening,
            bool isPremiumReservation,
            int seatRow,
            int seatNr,
            bool isStudent
        )
        {
            _movieScreening = movieScreening;
            _isPremium = isPremiumReservation;
            _isStudent = isStudent;
            _rowNr = seatRow;
            _seatNr = seatNr;
        }

        public bool IsPremiumTicket()
        {
            return _isPremium;
        }

        public bool IsStudentTicket()
        {
            return _isStudent;
        }

        public double GetPrice()
        {
            Double price = _movieScreening.PetPricePerSeat();
            if (_isPremium)
            {
                if (_isStudent) price += 2;
                else price += 3;
            }
            return price;
        }

        public DateTime GetScreeningDateAndTime()
        {
            return _movieScreening.DateAndTime();
        }

        public override string ToString()
        {
            return $"Movie: {_movieScreening.GetMovieTitle()}{Environment.NewLine}Screening: {GetScreeningDateAndTime()}{Environment.NewLine}Premium: {(IsPremiumTicket() ? "Yes" : "No")}{Environment.NewLine}Price: {GetPrice()}{Environment.NewLine}Row: {_rowNr}{Environment.NewLine}Seat: {_seatNr}";
        }
    }
}

