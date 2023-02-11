using System;
namespace Cinema
{
    public interface TicketType
    {
        public double GetPrice(VisitorType visitorType);
    }
}
