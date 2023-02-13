namespace Cinema
{
    public interface IOrderState
    {

        public void SubmitOrder();
        public void EditOrder(Order order);
        public void PayOrder();
        public void CancelOrder();
    }
}