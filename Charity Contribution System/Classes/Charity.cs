using Charity_Contribution_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Contribution_System.Classes
{
    //base class implementing the ICharity interface.
    abstract class Charity : ICharity
    {
        //Properties
        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public decimal TotalDonations { get; protected set; }

        //Custom Constructors
        protected Charity(string name, string description, decimal totalDonations)
        {
            this.Name = name;
            this.Description = description;
            this.TotalDonations = totalDonations;
        }

        //Data Structures
        public List<string> Feedback { get; private set; } 
        public List<decimal> DonationHistory { get; private set; }

        //Methods
        public void Donate(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void GetDetails()
        {
            throw new NotImplementedException();
        }

        public void GiveFeedback(string feedback)
        {
            throw new NotImplementedException();
        }
    }
}
