namespace capstone
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int VisitCount { get; set; } = 0;
        public bool IsGoldMember { get; set; }
        public DateTime? GoldMembershipExpiry { get; set; } = null;

        public bool GoldMembershipActive =>
            IsGoldMember && GoldMembershipExpiry.HasValue &&
            GoldMembershipExpiry >= DateTime.Now;
    }
}