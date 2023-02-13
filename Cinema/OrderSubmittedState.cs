namespace Cinema
{
    public class OrderSubmittedState : IOrderState
    {
        private Order _order;

        public OrderSubmittedState(Order order)
        {
            _order = order;
        }

        public void CancelOrder()
        {
            _order.SetState(_order._orderCancelledState);
        }

        public void EditOrder(Order order)
        {
            _order = order;
        }

        public void PayOrder()
        {
            _order.SetState(_order._orderPaidState);
        }

        public void SubmitOrder()
        {
            throw new Exception("Order has already been submitted. Can not submit.");
        }
    }
}