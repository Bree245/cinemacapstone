using System;

namespace capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            CinemaSystem cinema = new CinemaSystem();
            cinema.LoadMembers();
            cinema.LoadScreenings();

            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.Clear();
                Console.WriteLine("=== CINEMA MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Sell Tickets & Concessions");
                Console.WriteLine("2. Set Daily Schedule");
                Console.WriteLine("3. Add Screening");
                Console.WriteLine("4. Upgrade Member to Gold");
                Console.WriteLine("5. Manage Loyalty Members");
                Console.WriteLine("6. Save Data");
                Console.WriteLine("7. Load Data");
                Console.WriteLine("8. View Members");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        cinema.SellTicketAndConcessions();
                        break;
                    case "2":
                        cinema.SetDailySchedule();
                        break;
                    case "3":
                        cinema.AddScreeningFromUser();
                        break;
                    case "4":
                        cinema.UpgradeMemberToGold();
                        break;
                    case "5":
                        cinema.ManageLoyaltyMembers();
                        break;
                    case "6":
                        cinema.SaveMembers();
                        cinema.SaveScreenings();
                        Console.WriteLine("Data saved successfully.");
                        break;
                    case "7":
                        cinema.LoadMembers();
                        cinema.LoadScreenings();
                        Console.WriteLine("Data loaded successfully.");
                        break;
                    case "8":
                        cinema.ViewMembers();
                        break;
                    case "9":
                        exitRequested = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (!exitRequested)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Thank you for using the Cinema Management System!");
        }
    }
}