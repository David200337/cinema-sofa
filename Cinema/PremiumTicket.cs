using System;
using System.Diagnostics;

namespace Cinema
{
    public class PremiumTicket : ITicketType
    {
        public double GetPrice(IVisitorType visitorType)
        {
            // Return the added premium price if the ticket is a premium ticket.
            // For students this adds another €2,- to the regular price,
            // for non-students the added fee is €3,-. 
            switch (visitorType)
            {
                case StudentVisitor:
                    return 2;
                case RegularVisitor:
                    return 3;
            }

            return -1;
        }
    }
}
