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
    internal class User : IDataPersistable
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Wallet { get; set; }


        private const string ProjectName = "Charity Contribution System";
        private const string LocalStorageFolder = "LocalStorage";
        private const string FileName = "users.json";

        public User() { } 

        public User(string username, string password, decimal wallet)
        {
            Username = username;
            Password = password;
            Wallet = wallet;
        }

        public static List<User> ListOfUsers = new List<User>()
        {
            new User("johnDoe", "password123", 500.00m),
            new User("janeSmith", "securePass", 750.50m),
            new User("alexBrown", "abc1234", 1200.75m),
            new User("chrisJones", "qwerty987", 300.25m)
        };

        public void SaveData()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string projectPath = Path.Combine(desktopPath, "Programming_281", ProjectName);
                string fullPath = Path.Combine(projectPath, LocalStorageFolder, FileName);

                string directoryPath = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(ListOfUsers, options);
                File.WriteAllText(fullPath, jsonString);
                Console.WriteLine("Successfully saved data to users.json");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LoadData()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string projectPath = Path.Combine(desktopPath, "Programming_281", ProjectName);
                string fullPath = Path.Combine(projectPath, LocalStorageFolder, FileName);

                if (File.Exists(fullPath))
                {
                    string jsonString = File.ReadAllText(fullPath);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    ListOfUsers = JsonSerializer.Deserialize<List<User>>(jsonString, options);
                    Console.WriteLine("Successfully loaded data from users.json");
                }
                else
                {
                    // If file doesn't exist, initialize with default list and save
                    SaveData();
                    User.SaveUserData();
                    Console.WriteLine("Initialized saved data locally and then loaded data from users.json");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public delegate void Data();

        public static void SaveUserData()
        {
            Thread thread = new Thread(() =>
            {
                Data SaveData = new User().SaveData;
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
                Data LoadData = new User().LoadData;
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
