using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Contribution_System.Interfaces
{
    internal interface ICharity //Defines the core properties and methods for charity entities.
    {
        //Properties
        string Name { get; } 
        string Description { get; }
        
        //Methods
        void Donate(decimal amount); 
        void GetDetails(); 
        void GiveFeedback(string feedback);
        
        //Data structure
        List<decimal> DonationHistory { get; }
    }
}
