namespace capstone
{
    public class Ticket : ISellable
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string MovieName { get; private set; }
        public bool IsPremium { get; private set; }

        public Ticket(string movieName, decimal price, bool isPremium)
        {
            MovieName = movieName;
            Price = price;
            IsPremium = isPremium;
            Name = isPremium ? $"{movieName} - Premium Ticket" : $"{movieName} - Standard Ticket";
        }
    }
}