namespace capstone
{
    public class Screening
    {
        public string MovieName { get; set; }
        public string Screen { get; set; }
        public DateTime StartTime { get; set; }
        public int AgeRating { get; set; }
        public int StandardSeats { get; set; }
        public int PremiumSeats { get; set; }
        public int SoldStandard { get; set; } = 0;
        public int SoldPremium { get; set; } = 0;
        public decimal StandardPrice { get; set; }
        public decimal PremiumPrice { get; set; }

        public int TurnaroundTime =>
            (StandardSeats + PremiumSeats) <= 50 ? 15 :
            (StandardSeats + PremiumSeats) <= 100 ? 30 : 45;
    }
}