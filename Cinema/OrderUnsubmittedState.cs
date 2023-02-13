namespace Cinema
{
    public class OrderUnsubmittedState : IOrderState
    {
        private Order _order;

        public OrderUnsubmittedState(Order order)
        {
            _order = order;
        }

        public void CancelOrder()
        {
            throw new Exception("Order has not been submitted yet.");
        }

        public void EditOrder(MovieTicket ticket)
        {
            _order.AddSeatReservation(ticket);
        }

        public void PayOrder()
        {
            throw new Exception("Order has not been submitted yet.");
        }

        public void SubmitOrder()
        {
            _order.SetState(_order._orderSubmittedState);
        }
    }
}