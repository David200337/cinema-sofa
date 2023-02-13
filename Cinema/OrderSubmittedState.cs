namespace Cinema
{
    public class OrderSubmittedState : IOrderState
    {
        private readonly Order _order;

        public OrderSubmittedState(Order order)
        {
            _order = order;
        }

        public void CancelOrder()
        {
            _order.SetState(_order._orderCancelledState);
        }

        public void EditOrder(MovieTicket ticket)
        {
            _order.AddSeatReservation(ticket);
        }

        public void PayOrder()
        {
            _order.SetState(_order._orderPaidState);
        }

        public void SubmitOrder()
        {
            throw new InvalidOperationException("Order has already been submitted. Can not submit.");
        }
    }
}