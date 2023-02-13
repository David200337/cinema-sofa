using System.Net.Sockets;

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

    [TestMethod]
    public void Order_Should_Be_Able_To_Be_Submitted() 
    {  
        // Arrange
        Order order = new(1, true);

        // Act
        order.SubmitOrder();

        // Assert
        Assert.AreEqual(order._orderSubmittedState, order._state, $"State {order._state} and {order._orderSubmittedState} do not match.");
    }

    [TestMethod]
    [ExpectedException(typeof(Exception),
    "Order has not been submitted.")]
    public void Order_Should_Not_Be_Able_To_Be_Submitted_When_Submitted_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderSubmittedState);

        // Act
        order.SubmitOrder();
    }

    [TestMethod]
    [ExpectedException(typeof(Exception),
    "Order has not been submitted.")]
    public void Order_Should_Not_Be_Able_To_Be_Submitted_When_Provisional_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderProvisionalState);

        // Act
        order.SubmitOrder();
    }

    [TestMethod]
    [ExpectedException(typeof(Exception),
    "Order has not been submitted.")]
    public void Order_Should_Not_Be_Able_To_Be_Submitted_When_Paid_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderPaidState);

        // Act
        order.SubmitOrder();
    }

    [TestMethod]
    [ExpectedException(typeof(Exception),
    "Order has not been submitted.")]
    public void Order_Should_Not_Be_Able_To_Be_Submitted_When_Cancelled_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderCancelledState);

        // Act
        order.SubmitOrder();
    }

    [DataTestMethod]
    [DataRow(10.00, false, false, false, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, true, true, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, false, false, 3, 20.00)]
    public void Order_Should_Be_Able_To_Be_Editted_When_Unsubtmitted_State(double baseTicketPrice, bool isPremiumTicket, bool isStudentTicket, bool isWeekend, int amountOfTickets, double expectedOrderPrice)
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
        order.EditOrder(new MovieTicket(movieScreening, 7, 7, new PremiumTicket(), new StudentVisitor()));

        // Assert
        Assert.IsTrue(order._tickets.Count == amountOfTickets + 1, $"New ticket count does not equal {amountOfTickets + 1}.");
    }

    [DataTestMethod]
    [DataRow(10.00, false, false, false, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, true, true, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, false, false, 3, 20.00)]
    public void Order_Should_Be_Able_To_Be_Editted_When_Subtmitted_State(double baseTicketPrice, bool isPremiumTicket, bool isStudentTicket, bool isWeekend, int amountOfTickets, double expectedOrderPrice)
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
        order.SetState(order._orderSubmittedState);

        // Act
        order.EditOrder(new MovieTicket(movieScreening, 7, 7, new PremiumTicket(), new StudentVisitor()));

        // Assert
        Assert.IsTrue(order._tickets.Count == amountOfTickets + 1, $"New ticket count does not equal {amountOfTickets + 1}.");
    }

    [DataTestMethod]
    [DataRow(10.00, false, false, false, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, true, true, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, false, false, 3, 20.00)]
    public void Order_Should_Be_Able_To_Be_Editted_When_Provisional_State(double baseTicketPrice, bool isPremiumTicket, bool isStudentTicket, bool isWeekend, int amountOfTickets, double expectedOrderPrice)
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
        order.SetState(order._orderProvisionalState);

        // Act
        order.EditOrder(new MovieTicket(movieScreening, 7, 7, new PremiumTicket(), new StudentVisitor()));

        // Assert
        Assert.IsTrue(order._tickets.Count == amountOfTickets + 1, $"New ticket count does not equal {amountOfTickets + 1}.");
    }


    [DataTestMethod]
    [DataRow(10.00, false, false, false, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, true, true, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, false, false, 3, 20.00)]
    [ExpectedException(typeof(Exception),"Order has not been paid for.")]
    public void Order_Should_Not_Be_Able_To_Be_Editted_When_Paid_State(double baseTicketPrice, bool isPremiumTicket, bool isStudentTicket, bool isWeekend, int amountOfTickets, double expectedOrderPrice)
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
        order.SetState(order._orderPaidState);

        // Act
        order.EditOrder(new MovieTicket(movieScreening, 7, 7, new PremiumTicket(), new StudentVisitor()));

        // Assert
        Assert.IsFalse(order._tickets.Count == amountOfTickets + 1, $"New ticket count equals {amountOfTickets + 1}.");
    }

    [DataTestMethod]
    [DataRow(10.00, false, false, false, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, true, true, 6, 30.00)]
    [DataRow(10.00, false, false, true, 6, 54.00)]
    [DataRow(10.00, false, false, false, 3, 20.00)]
    [ExpectedException(typeof(Exception), "Order has not been cancelled.")]
    public void Order_Should_Not_Be_Able_To_Be_Editted_When_Cancelled_State(double baseTicketPrice, bool isPremiumTicket, bool isStudentTicket, bool isWeekend, int amountOfTickets, double expectedOrderPrice)
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
        order.SetState(order._orderPaidState);

        // Act
        order.EditOrder(new MovieTicket(movieScreening, 7, 7, new PremiumTicket(), new StudentVisitor()));

        // Assert
        Assert.IsFalse(order._tickets.Count == amountOfTickets + 1, $"New ticket count equals {amountOfTickets + 1}.");
    }

    [TestMethod]
    public void Order_Should_Be_Able_To_Be_Paid_For_When_Submitted_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderSubmittedState);

        // Act
        order.PayOrder();

        // Assert
        Assert.AreEqual(order._orderPaidState, order._state, $"State {order._state} and {order._orderPaidState} do not match.");
    }

    [TestMethod]
    public void Order_Should_Be_Able_To_Be_Paid_For_When_Provisional_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderProvisionalState);

        // Act
        order.PayOrder();

        // Assert
        Assert.AreEqual(order._orderPaidState, order._state, $"State {order._state} and {order._orderPaidState} do not match.");
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Order has been submitted.")]
    public void Order_Should_Not_Be_Able_To_Be_Paid_For_When_Unsubmitted_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderUnsubmittedState);

        // Act
        order.PayOrder();

        // Assert
        Assert.AreNotEqual(order._orderPaidState, order._state, $"State {order._state} and {order._orderPaidState} match.");
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Order has not been paid for.")]
    public void Order_Should_Not_Be_Able_To_Be_Paid_For_When_Paid_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderPaidState);

        // Act
        order.PayOrder();

        // Assert
        Assert.AreNotEqual(order._orderPaidState, order._state, $"State {order._state} and {order._orderPaidState} match.");
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Order has not been cancelled.")]
    public void Order_Should_Not_Be_Able_To_Be_Paid_For_When_Cancelled_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderCancelledState);

        // Act
        order.PayOrder();

        // Assert
        Assert.AreNotEqual(order._orderPaidState, order._state, $"State {order._state} and {order._orderPaidState} match.");
    }

    [TestMethod]
    public void Order_Should_Be_Able_To_Be_Cancelled_For_When_Submitted_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderSubmittedState);

        // Act
        order.CancelOrder();

        // Assert
        Assert.AreEqual(order._orderCancelledState, order._state, $"State {order._state} and {order._orderCancelledState} do not match.");
    }

    [TestMethod]
    public void Order_Should_Be_Able_To_Be_Cancelled_For_When_Provisional_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderProvisionalState);

        // Act
        order.CancelOrder();

        // Assert
        Assert.AreEqual(order._orderCancelledState, order._state, $"State {order._state} and {order._orderCancelledState} do not match.");
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Order is submitted.")]
    public void Order_Should_Not_Be_Able_To_Be_Cancelled_For_When_Unsubmitted_State()
    {
        // Arrange
        Order order = new(1, true);

        // Act
        order.CancelOrder();

        // Assert
        Assert.AreNotEqual(order._orderCancelledState, order._state, $"State {order._state} and {order._orderCancelledState} match.");
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Order is not paid for.")]
    public void Order_Should_Not_Be_Able_To_Be_Cancelled_For_When_Paid_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderPaidState);

        // Act
        order.CancelOrder();

        // Assert
        Assert.AreNotEqual(order._orderCancelledState, order._state, $"State {order._state} and {order._orderCancelledState} match.");
    }

    [TestMethod]
    [ExpectedException(typeof(Exception), "Order has not been cancelled.")]
    public void Order_Should_Not_Be_Able_To_Be_Cancelled_For_When_Cancelled_State()
    {
        // Arrange
        Order order = new(1, true);
        order.SetState(order._orderCancelledState);

        // Act
        order.CancelOrder();

        // Assert
        Assert.AreNotEqual(order._orderCancelledState, order._state, $"State {order._state} and {order._orderCancelledState} match.");
    }
}
