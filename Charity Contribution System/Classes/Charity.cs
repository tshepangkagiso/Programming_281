using Charity_Contribution_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Contribution_System.Classes
{
    //base class implementing the ICharity interface.
    public abstract class Charity : ICharity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalDonations { get; set; }
        public List<string> Feedback { get; set; } = new List<string>();
        public List<decimal> DonationHistory { get; set; } = new List<decimal>();

        // Parameterless constructor for deserialization
        protected Charity() { }

        protected Charity(string name, string description, decimal totalDonations)
        {
            Name = name;
            Description = description;
            TotalDonations = totalDonations;
        }

        public virtual void Donate(decimal amount)
        {
            throw new NotImplementedException();
        }

        public virtual void GetDetails()
        {
            throw new NotImplementedException();
        }

        public virtual void GiveFeedback(string feedback)
        {
            throw new NotImplementedException();
        }
    }
}
