using System;
using System.Text.Json.Serialization;

namespace Cinema
{
    public class MovieTicket
    {
        [JsonInclude, JsonPropertyName("MovieScreening")]
        public MovieScreening _movieScreening { get; private set; }

        [JsonInclude, JsonPropertyName("RowNr")]
        public int _rowNr { get; private set; }

        [JsonInclude, JsonPropertyName("SeatNr")]
        public int _seatNr { get; private set; }

        public ITicketType _ticketType { get; private set; }

        public IVisitorType _visitorType { get; private set; }


        public MovieTicket(
            MovieScreening movieScreening,
            int seatRow,
            int seatNr,
            ITicketType ticketType,
            IVisitorType visitorType
        )
        {
            _movieScreening = movieScreening;
            _rowNr = seatRow;
            _seatNr = seatNr;
            _ticketType = ticketType;
            _visitorType = visitorType;
        }

        public bool IsPremiumTicket()
        {
            return _ticketType is PremiumTicket;
        }

        public bool IsStudentTicket()
        {
            return _visitorType is StudentVisitor;
        }

        public double GetPrice()
        {
            double price = _movieScreening._pricePerSeat;

            return price + _ticketType.GetPrice(_visitorType);
        }

        public DateTime GetScreeningDateAndTime()
        {
            return _movieScreening._dateAndTime;
        }

        public override string ToString()
        {
            return $"Movie: {_movieScreening.GetMovieTitle()}{Environment.NewLine}Screening: {GetScreeningDateAndTime()}{Environment.NewLine}Premium: {(IsPremiumTicket() ? "Yes" : "No")}{Environment.NewLine}Price: {GetPrice()}{Environment.NewLine}Row: {_rowNr}{Environment.NewLine}Seat: {_seatNr}";
        }
    }
}

