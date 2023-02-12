using System;
namespace Cinema
{
    public class RegularTicket : ITicketType
    {
        public double GetPrice(IVisitorType visitorType)
        {
            // Return no added price if the ticket is not a regular ticket.
            return 0;
        }
    }
}
