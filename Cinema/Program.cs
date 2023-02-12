namespace Cinema
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var movie = new Movie("Hello");

            var screening = new MovieScreening(movie, DateTime.Now, 2.00);

            var ticket = new MovieTicket(screening, 2, 1, new RegularTicket(), new StudentVisitor());

            var order = new Order(1, true);

            order.AddSeatReservation(ticket);

            order.Export(new JsonExport());
        }
    }
}
