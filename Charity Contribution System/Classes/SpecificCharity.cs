using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Contribution_System.Classes
{
    //represents individual charity entities with specific attributes and methods.
    public class SpecificCharity : Charity
    {
        public string CharityType { get; set; }
        public SpecificCharity() : base() { }

        public SpecificCharity(string name, string description, string charityType, decimal totalDonations) : base(name, description, totalDonations)
        {
            CharityType = charityType;
        }


        public override void Donate(decimal amount)
        {
            TotalDonations += amount;
            DonationHistory.Add(amount);
            Console.WriteLine($"Thank you for donating {amount:C} to {Name}!");
        }

        public override void GetDetails()
        {
            Console.WriteLine("Charity Details:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Type: {CharityType}");
            Console.WriteLine($"Total Donations: {TotalDonations:C}");

            if (DonationHistory.Count > 0)
            {
                Console.WriteLine("Donation History:");
                foreach (var donation in DonationHistory)
                {
                    Console.WriteLine($"- {donation:C}");
                }
            }
            else
            {
                Console.WriteLine("No donations have been made yet.");
            }
        }

        public override void GiveFeedback(string feedback)
        {
            Feedback.Add(feedback);
            Console.WriteLine($"Thank you for your feedback on {Name}: \"{feedback}\"");
        }
    }
}
