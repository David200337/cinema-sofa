namespace Cinema
{
    public interface IOrderState
    {

        public void SubmitOrder();
        public void EditOrder(MovieTicket ticket);
        public void PayOrder();
        public void CancelOrder();
    }
}