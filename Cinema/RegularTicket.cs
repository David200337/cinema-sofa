using System;
namespace Cinema
{
    public class RegularTicket : TicketType
    {
        public double GetPrice(VisitorType visitorType)
        {
            // Return no added price if the ticket is not a regular ticket.
            return 0;
        }
    }
}
