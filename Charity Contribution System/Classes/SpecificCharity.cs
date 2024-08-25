using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Contribution_System.Classes
{
    //represents individual charity entities with specific attributes and methods.
    internal class SpecificCharity : Charity
    {
        private string CharityType { get; set; }
        public SpecificCharity(string name, string description, string charityType ,decimal totalDonations) : base(name, description, totalDonations)
        {
            this._CharityType = charityType;
        }

        public string _CharityType { get { return CharityType; } set { CharityType = value; } }
    }
}
