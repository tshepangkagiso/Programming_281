using Charity_Contribution_System.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Charity_Contribution_System.Classes
{
    //Represents a user of the system with attributes such as Name, Email, and methods for interacting with charities.
    //Use Encapsulation here.
    internal class User: IDataPersistable
    {
        private string Username {  get; set; }
        private string Password { get; set; }
        private decimal Wallet {  get; set; }

        private const string FilePath = @"C:\Users\tshep\OneDrive\Desktop\Programming_281\Charity Contribution System\LocalStorage\users.json";

        public User(string username, string password, decimal wallet)
        {
            this._Username = username;
            this._Password = password;
            this._Wallet = wallet;
        }

        public string _Username { get { return Username; } set { if (value != null) { Username = value; } else { Username = "Did not specify name"; } } }
        public string _Password { get { return Password; } set { if (value != null) { Password = value; } else { Username = "Did not enter password"; } } }

        public decimal _Wallet { get { return Wallet; } set { if (value > 0) { Wallet = value; } else { Wallet = 0m; } } }

        public static List<User> ListOfUsers = new List<User>()
        {
            new User("johnDoe", "password123", 500.00m),
            new User("janeSmith", "securePass", 750.50m),
            new User("alexBrown", "abc1234", 1200.75m),
            new User("chrisJones", "qwerty987", 300.25m)
        };

        // Method to save changes to charities.json, that occured in ListOfCharities.
        public void SaveData()
        {

        }

        // Method to load existing list of charities.
        public void LoadData()
        {
        }

        //Methods we call outside this call that reference internal methods.
        public delegate void data();
        public static void SaveUserData()
        {
            Thread thread = new Thread(() =>
            {
                data SaveData = new User("","",0m).SaveData;
                lock (ListOfUsers)
                {
                    SaveData.Invoke();
                }

            });
  
            thread.Start();
            thread.Join();

        }

        public static void LoadUserData()
        {
            Thread thread = new Thread(() =>
            {
                data LoadData = new User("", "", 0m).LoadData;
                lock (ListOfUsers)
                {
                    LoadData.Invoke();
                }
                
            });

            thread.Start();
            thread.Join();

        }
    }
}
