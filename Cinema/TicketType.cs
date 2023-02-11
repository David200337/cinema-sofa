using System;
namespace Cinema
{
    public interface ITicketType
    {
        public double GetPrice(IVisitorType visitorType);
    }
}
