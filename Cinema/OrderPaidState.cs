namespace Cinema {
    public class OrderPaidState : IOrderState
    {
        private readonly Order _order;

        public OrderPaidState(Order order)
        {
            _order = order;
        }

        public void CancelOrder()
        {
            throw new InvalidOperationException("Order has already been paid for. Can not cancel.");
        }

        public void EditOrder(MovieTicket ticket)
        {
            throw new InvalidOperationException("Order has already been paid for. Can not edit.");
        }

        public void PayOrder()
        {
            throw new InvalidOperationException("Order has already been paid for.");
        }

        public void SubmitOrder()
        {
            throw new InvalidOperationException("Order has already been submitted and paid for. Can not submit.");
        }
    }
}