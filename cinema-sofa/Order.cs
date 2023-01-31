using System;
namespace cinema_sofa
{
    public class Order
    {
        private List<MovieTicket> _tickets;
        private int _orderNr;
        private bool _isStudent;

        public Order(int orderNr, bool isStudentOrder)
        {
            _tickets = new List<MovieTicket>();
            _orderNr = orderNr;
            _isStudent = isStudentOrder;
        }

        public int getOrderNr()
        {
            return _orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            _tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            // TODO: Implement
            return 0.0;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            // TODO: Implement
        }
    }
}

