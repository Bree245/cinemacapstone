namespace capstone
{
    public class Member
    {
        public string Name { get; private set; }
        public int VisitCount { get; private set; }

        public Member(string name)
        {
            Name = name;
            VisitCount = 0;
        }

        public void RecordVisit(decimal amountSpent)
        {
            VisitCount++;
        }

        public bool IsEligibleForFreeTicket()
        {
            return VisitCount >= 10;
        }

        public virtual decimal ApplyDiscount(decimal total)
        {
            return total; // Regular members get no discount
        }

        public void SetVisitCount(int visits)
        {
            VisitCount = visits;
        }

        public override string ToString()
        {
            return $"{Name} - Visits: {VisitCount} - Regular Member";
        }
    }
}