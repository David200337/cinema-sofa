namespace Cinema.Tests;

[TestClass]
public class OrderTests
{
    [DataTestMethod]
    [DataRow(10.00, false, false, false, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, true, true, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, false, false, 3, 20.00)]
    public void Order_Price_Is_Correctly_Calculated(double baseTicketPrice, bool isPremiumTicket, bool isStudentTicket, bool isWeekend, int amountOfTickets, double expectedOrderPrice)
    {
        // Arrange
        DateTime today = DateTime.Now.Date;
        DayOfWeek desiredDay = isWeekend ? DayOfWeek.Friday : DayOfWeek.Monday;
        int offset = Utils.CalculateOffset(today.DayOfWeek, desiredDay);
        DateTime screeningDate = today.AddDays(offset);

        Movie movie = new("Test movie");
        MovieScreening movieScreening = new(movie, screeningDate, baseTicketPrice);
        movie.AddScreening(movieScreening);

        Order order = new(1, isStudentTicket);
        for (int i = 0; i < amountOfTickets; i++)
        {
            ITicketType ticketType = isPremiumTicket ? new PremiumTicket() : new RegularTicket();
            IVisitorType visitorType = isStudentTicket ? new StudentVisitor() : new RegularVisitor();

            order.AddSeatReservation(new MovieTicket(movieScreening, i, i, ticketType, visitorType));
        }

        // Act
        double actualOrderPrice = order.CalculatePrice();

        // Assert
        Assert.AreEqual(expectedOrderPrice, actualOrderPrice, $"The expected total order price of {expectedOrderPrice} does not meet the actual total order price of {actualOrderPrice}.");
    }

    public void Order_Should_Be_Able_To_Be_Submitted() 
    {  
        // Arrange
        Order order = new(1, true);

        // Act
        order.SubmitOrder();

        // Assert
        Assert.AreEqual(order._orderSubmittedState, order._state, $"State {order._state} and {order._orderSubmittedState} do not match.");
    }
}
