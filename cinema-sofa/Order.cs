using System.Text.Json;
using System.Text.Json.Serialization;

namespace cinema_sofa
{
    public class Order
    {
        [JsonInclude, JsonPropertyName("Tickets")]
        public List<MovieTicket> _tickets { get; private set; }

        [JsonInclude, JsonPropertyName("OderNr")]
        public int _orderNr { get; private set; }

        public Order(int orderNr, bool isStudentOrder)
        {
            _tickets = new List<MovieTicket>();
            _orderNr = orderNr;
        }

        public int GetOrderNr()
        {
            return _orderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            _tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            Double currentOrderPrice = 0;

            // Using a for loop to track the index of a C# list. Foreach doesn't support this feature, nor does a map() function exist as in Typescript.
            for (int i = 0; i < _tickets.Count; i++)
            {
                MovieTicket ticket = _tickets[i];
                Double ticketPrice = ticket.GetPrice();

                if (((i + 1) % 2 == 0) && (((int)ticket.GetScreeningDateAndTime().DayOfWeek < 5 && (int)ticket.GetScreeningDateAndTime().DayOfWeek > 0) || ticket.IsStudentTicket()))
                {
                    ticketPrice = 0;
                }

                if (!ticket.IsStudentTicket() && ((int)ticket.GetScreeningDateAndTime().DayOfWeek > 4 || (int)ticket.GetScreeningDateAndTime().DayOfWeek == 0) && _tickets.Count >= 6)
                {
                    ticketPrice = ticketPrice * 0.9;
                }

                currentOrderPrice += ticketPrice;
            }

            return currentOrderPrice;
        }

        public void Export(TicketExportFormat exportFormat)
        {

            var fileName = "Order";
            var extension = "";
            var jsonString = JsonSerializer.Serialize(this);

            switch (exportFormat)
            {
                case TicketExportFormat.PLAINTEXT:
                    extension = "txt";
                    break;
                case TicketExportFormat.JSON:
                    extension = "json";
                    break;
            }

            File.WriteAllText($"{fileName}.{extension}", jsonString);
        }
    }
}

