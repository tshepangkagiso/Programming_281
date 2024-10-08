using System;

namespace Charity_Contribution_System.Classes
{
    public class Donation
    {
        public string CharityName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Donation(string charityName, decimal amount, DateTime date)
        {
            CharityName = charityName;
            Amount = amount;
            Date = date;
        }
    }
}
