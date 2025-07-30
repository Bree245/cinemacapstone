namespace capstone
{
    public class Concession : ISellable
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Concession(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}