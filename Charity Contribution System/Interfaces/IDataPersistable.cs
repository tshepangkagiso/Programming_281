using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Contribution_System.Interfaces
{
    internal interface IDataPersistable // Ensures that data can be saved and loaded consistently. 
    {
        //Methods
        void SaveData(); 
        void LoadData();
    }
}
