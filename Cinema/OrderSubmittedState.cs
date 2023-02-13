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