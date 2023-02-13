namespace Cinema {
    public class OrderPaidState : IOrderState
    {
        private Order _order;

        public OrderPaidState(Order order)
        {
            _order = order;
        }

        public void CancelOrder()
        {
            throw new Exception("Order has already been paid for. Can not cancel.");
        }

        public void EditOrder(MovieTicket ticket)
        {
            throw new Exception("Order has already been paid for. Can not edit.");
        }

        public void PayOrder()
        {
            throw new Exception("Order has already been paid for.");
        }

        public void SubmitOrder()
        {
            throw new Exception("Order has already been submitted and paid for. Can not submit.");
        }
    }
}