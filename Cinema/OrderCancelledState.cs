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
            throw new NotImplementedException();
        }

        public void EditOrder()
        {
            throw new NotImplementedException();
        }

        public void PayOrder()
        {
            throw new NotImplementedException();
        }

        public void SubmitOrder()
        {
            throw new NotImplementedException();
        }
    }
}