using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace capstone
{
    public class CinemaSystem
    {
        private List<Screening> screenings = new List<Screening>();
        private List<Member> members = new List<Member>();
        private const string MembersFile = "members.txt";
        private const string ScreeningsFile = "screenings.txt";

        // --- 1. Selling Tickets & Concessions ---
        public void SellTicketAndConcessions()
        {
            Console.Write("Enter member name (or leave blank for guest): ");
            string name = Console.ReadLine();
            Member member = members.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrWhiteSpace(name))
            {
                member = new Member("Guest");
            }
            else if (member == null)
            {
                Console.WriteLine("Member not found. Adding as new member.");
                member = new Member(name);
                members.Add(member);
            }

            if (!screenings.Any())
            {
                Console.WriteLine("No screenings available.");
                return;
            }

            Console.WriteLine("Available screenings:");
            for (int i = 0; i < screenings.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {screenings[i]}");
            }

            Console.Write("Select screening: ");
            if (!int.TryParse(Console.ReadLine(), out int screeningChoice) || screeningChoice < 1 || screeningChoice > screenings.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Screening selectedScreening = screenings[screeningChoice - 1];

            Console.Write("Ticket type (1=Standard, 2=Premium): ");
            bool premium = Console.ReadLine() == "2";
            decimal ticketPrice = premium ? selectedScreening.PremiumPrice : selectedScreening.StandardPrice;

            Console.Write("Number of tickets: ");
            int ticketCount = int.Parse(Console.ReadLine());

            decimal total = ticketPrice * ticketCount;

            Console.Write("Add concessions? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Enter concession price: ");
                decimal concessionPrice = decimal.Parse(Console.ReadLine());
                total += concessionPrice;
            }

            total = member.ApplyDiscount(total);
            member.RecordVisit(total);

            Console.WriteLine($"Total after discount: £{total:F2}");
        }

        // --- 2. Setting Daily Schedule ---
        public void SetDailySchedule()
        {
            Console.WriteLine("Setting daily schedule...");
            AddScreeningFromUser();
        }

        public void AddScreeningFromUser()
        {
            Console.Write("Enter movie name: ");
            string movie = Console.ReadLine();

            Console.Write("Enter screen letter: ");
            string screen = Console.ReadLine();

            Console.Write("Enter start time (yyyy-mm-dd HH:mm): ");
            DateTime start = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter age rating: ");
            int rating = int.Parse(Console.ReadLine());

            Console.Write("Enter standard seats: ");
            int standardSeats = int.Parse(Console.ReadLine());

            Console.Write("Enter premium seats: ");
            int premiumSeats = int.Parse(Console.ReadLine());

            Console.Write("Enter standard price: ");
            decimal standardPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter premium price: ");
            decimal premiumPrice = decimal.Parse(Console.ReadLine());

            screenings.Add(new Screening
            {
                MovieName = movie,
                Screen = screen,
                StartTime = start,
                AgeRating = rating,
                StandardSeats = standardSeats,
                PremiumSeats = premiumSeats,
                StandardPrice = standardPrice,
                PremiumPrice = premiumPrice
            });

            Console.WriteLine("Screening added.");
        }

        // --- 3. Loyalty Scheme ---
        public void ManageLoyaltyMembers()
        {
            Console.WriteLine("1. Add new member");
            Console.WriteLine("2. Record visit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter member name: ");
                string name = Console.ReadLine();
                members.Add(new Member(name));
                Console.WriteLine("Member added.");
            }
            else if (choice == "2")
            {
                Console.Write("Enter member name: ");
                string name = Console.ReadLine();
                var member = members.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (member != null)
                {
                    member.RecordVisit(0);
                    Console.WriteLine("Visit recorded.");
                }
            }
        }

        // --- 4. Gold Membership ---
        public void UpgradeMemberToGold()
        {
            Console.Write("Enter member name: ");
            string name = Console.ReadLine();
            var member = members.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (member != null)
            {
                members.Remove(member);
                members.Add(new GoldMember(name));
                Console.WriteLine("Member upgraded to Gold.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }

        // --- View Members ---
        public void ViewMembers()
        {
            foreach (var member in members)
            {
                Console.WriteLine(member);
            }
        }

        // --- Save & Load ---
        public void SaveMembers()
        {
            File.WriteAllLines(MembersFile, members.Select(m => $"{m.Name}|{m.VisitCount}|{(m is GoldMember ? "Gold" : "Regular")}"));
        }

        public void LoadMembers()
        {
            if (!File.Exists(MembersFile)) return;
            foreach (var line in File.ReadAllLines(MembersFile))
            {
                var parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    string name = parts[0];
                    int visits = int.Parse(parts[1]);
                    string type = parts[2];
                    Member member = type == "Gold" ? new GoldMember(name) : new Member(name);
                    member.SetVisitCount(visits);
                    members.Add(member);
                }
            }
        }

        public void SaveScreenings()
        {
            File.WriteAllLines(ScreeningsFile, screenings.Select(s => $"{s.MovieName}|{s.Screen}|{s.StartTime}|{s.AgeRating}|{s.StandardSeats}|{s.PremiumSeats}|{s.StandardPrice}|{s.PremiumPrice}"));
        }

        public void LoadScreenings()
        {
            if (!File.Exists(ScreeningsFile)) return;
            foreach (var line in File.ReadAllLines(ScreeningsFile))
            {
                var parts = line.Split('|');
                if (parts.Length >= 8)
                {
                    screenings.Add(new Screening
                    {
                        MovieName = parts[0],
                        Screen = parts[1],
                        StartTime = DateTime.Parse(parts[2]),
                        AgeRating = int.Parse(parts[3]),
                        StandardSeats = int.Parse(parts[4]),
                        PremiumSeats = int.Parse(parts[5]),
                        StandardPrice = decimal.Parse(parts[6]),
                        PremiumPrice = decimal.Parse(parts[7])
                    });
                }
            }
        }
    }
}