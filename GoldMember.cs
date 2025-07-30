namespace capstone
{
    public class GoldMember : Member
    {
        public GoldMember(string name) : base(name) { }

        public override decimal ApplyDiscount(decimal total)
        {
            return total * 0.75m; // 25% discount
        }

        public override string ToString()
        {
            return $"{Name} - Visits: {VisitCount} - GOLD Member (25% discount)";
        }
    }
}