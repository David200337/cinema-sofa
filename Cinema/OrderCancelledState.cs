namespace Cinema {
    public class OrderCancelledState : IOrderState
    {
        private Order _order;

        public OrderCancelledState(Order order)
        {
            _order = order;
        }

        public void CancelOrder()
        {
            throw new Exception("Order has already been cancelled.");
        }

        public void EditOrder(Order order)
        {
            throw new Exception("Order has been cancelled. Can not edit.");
        }

        public void PayOrder()
        {
            throw new Exception("Order has been cancelled. Can not pay.");
        }

        public void SubmitOrder()
        {
            throw new Exception("Order has already been submitted and cancelled.");
        }
    }
}