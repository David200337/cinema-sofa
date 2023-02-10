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
            order.AddSeatReservation(new MovieTicket(movieScreening, isPremiumTicket, i, i, isStudentTicket));
        }

        // Act
        double actualOrderPrice = order.CalculatePrice();

        // Assert
        Assert.AreEqual(expectedOrderPrice, actualOrderPrice, $"The expected total order price of {expectedOrderPrice} does not meet the actual total order price of {actualOrderPrice}.");
    }
}
