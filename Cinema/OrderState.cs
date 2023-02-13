namespace Cinema
{
    public interface IOrderState
    {

        public void SubmitOrder();
        public void EditOrder();
        public void PayOrder();
        public void CancelOrder();
    }
}