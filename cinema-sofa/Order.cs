using System;
namespace cinema_sofa
{
    public class Order
    {
        private List<MovieTicket> _tickets;
        private int _orderNr;

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

            if (_tickets.Count >= 6)
            {
                currentOrderPrice = currentOrderPrice * 0.9;
            }

            return currentOrderPrice;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            // TODO: Implement
        }
    }
}

