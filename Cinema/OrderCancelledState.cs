namespace Cinema {
    public class OrderCancelledState : IOrderState
    {
        private readonly Order _order;

        public OrderCancelledState(Order order)
        {
            _order = order;
        }

        public void CancelOrder()
        {
            throw new InvalidOperationException("Order has already been cancelled.");
        }

        public void EditOrder(MovieTicket ticket)
        {
            throw new InvalidOperationException("Order has been cancelled. Can not edit.");
        }

        public void PayOrder()
        {
            throw new InvalidOperationException("Order has been cancelled. Can not pay.");
        }

        public void SubmitOrder()
        {
            throw new InvalidOperationException("Order has already been submitted and cancelled.");
        }
    }
}