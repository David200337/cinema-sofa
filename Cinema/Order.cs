using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cinema
{
    public class Order
    {
        [JsonInclude, JsonPropertyName("Tickets")]
        public List<MovieTicket> _tickets { get; private set; }

        [JsonInclude, JsonPropertyName("OderNr")]
        public int _orderNr { get; private set; }

        public IOrderState _orderUnsubmittedState { get; private set; }
        public IOrderState _orderSubmittedState { get; private set; }
        public IOrderState _orderProvisionalState { get; private set; }
        public IOrderState _orderPaidState { get; private set; }
        public IOrderState _orderCancelledState { get; private set; }

        public IOrderState _state { get; private set; }

        public Order(int orderNr, bool isStudentOrder)
        {
            _tickets = new List<MovieTicket>();
            _orderNr = orderNr;
            _orderUnsubmittedState = new OrderUnsubmittedState(this);
            _orderSubmittedState = new OrderSubmittedState(this);
            _orderProvisionalState = new OrderProvisionalState(this);
            _orderPaidState = new OrderPaidState(this);
            _orderCancelledState = new OrderCancelledState(this);
            _state = _orderUnsubmittedState;
        }

        public void SubmitOrder()
        {
            _state.SubmitOrder();
        }

        public void EditOrder(Order order)
        {
            _state.EditOrder(order);
        }

        public void PayOrder()
        {
            _state.PayOrder();
        }

        public void CancelOrder()
        {
            _state.CancelOrder();
        }

        public void SetState(IOrderState state)
        {
            _state = state;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            _tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            double totalOrderPice = 0;

            // Using a for loop to track the index of a C# list. Foreach doesn't support this feature, nor does a map() function exist as in Typescript.
            for (int i = 0; i < _tickets.Count; i++)
            {
                MovieTicket ticket = _tickets[i];
                DateTime ticketDate = ticket.GetScreeningDateAndTime();
                double ticketPrice = ticket.GetPrice();

                bool isWeekDay = ticketDate.DayOfWeek >= DayOfWeek.Monday && ticketDate.DayOfWeek <= DayOfWeek.Thursday;
                bool isStudentTicket = ticket.IsStudentTicket();
                bool isSecondTicket = (i + 1) % 2 == 0;

                // The second ticket is free when it is a weekday,
                // or when the ticket is a student ticket.
                if (isSecondTicket && (isWeekDay || isStudentTicket))
                {
                    ticketPrice = 0;
                }

                // Additionally, a 10% discount is provided during the weekend when
                // the ticket is not a student ticket and the order consists of 6 or more orders.
                if (!isStudentTicket && !isWeekDay && _tickets.Count >= 6)
                {
                    ticketPrice *= 0.9;
                }

                // Add the calculated ticket price to the total order price.
                totalOrderPice += ticketPrice;
            }

            return totalOrderPice;
        }

        public void Export(IExportType exportType)
        {
            exportType.Export<Order>(this);
        }
    }
}

