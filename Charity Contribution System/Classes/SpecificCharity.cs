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
        public SpecificCharity(string name, string description, decimal totalDonations) : base(name, description, totalDonations)
        {
        }
    }
}
