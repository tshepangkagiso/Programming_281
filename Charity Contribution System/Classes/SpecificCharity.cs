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

        // Parameterless constructor for deserialization
        public SpecificCharity() : base() { }

        public SpecificCharity(string name, string description, string charityType, decimal totalDonations)
            : base(name, description, totalDonations)
        {
            CharityType = charityType;
        }
    }
}