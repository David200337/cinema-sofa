namespace Cinema
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var movie = new Movie("Hello");

            var screening = new MovieScreening(movie, DateTime.Now, 2.00);

            var ticket = new MovieTicket(screening, true, 2, 1, true);

            var order = new Order(1, true);

            order.AddSeatReservation(ticket);

            order.Export(TicketExportFormat.JSON);
        }
    }
}
