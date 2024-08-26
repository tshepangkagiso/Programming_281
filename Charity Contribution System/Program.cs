using Charity_Contribution_System.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Charity_Contribution_System
{
    internal class Program
    {
        enum MenuOptions
        {
            ViewAllCharities = 1,
            SearchCharities,
            Donate,
            LearnMore,
            GiveFeedback,
            ViewDonationHistory,
            Exit
        }

        enum Login_RegisterMenu
        {
            Login = 1,
            RegisterAndLoginIn,
            Exit
        }

        static void Main(string[] args)
        {
            try
            {
                LoadPersistentJsonData();
                User user = Login_Register();
                if (user != null)
                {
                    ApplicationProcess(user);
                }
                else
                {
                    Console.WriteLine("User not found or not registered.");
                    Exit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static int Menu()
        {
            try
            {
                Console.WriteLine("====================================================================================================== \n");
                foreach (MenuOptions option in Enum.GetValues(typeof(MenuOptions)))
                {
                    Console.WriteLine($"{(int)option}. {option.ToString()}");
                }
                Console.Write("\nEnter Menu choice between 1 - 7: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 0)
                {
                    Console.WriteLine("====================================================================================================== \n");
                    return choice;
                }
                else
                {
                    Console.WriteLine("Wrong input choice for Menu");
                    Console.WriteLine("====================================================================================================== \n");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static void Exit()
        {
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        public static User Login_Register()
        {
            try
            {
                Console.WriteLine("====================================================================================================== \n");
                foreach (Login_RegisterMenu option in Enum.GetValues(typeof(Login_RegisterMenu)))
                {
                    Console.WriteLine($"{(int)option}. {option.ToString()}");
                }
                Console.Write("Enter choice between 1 - 3 only: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 0)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Login confirmed.");
                            Console.Write("Enter Username: ");
                            string username = Console.ReadLine().Trim();
                            Console.Write("Enter Password: ");
                            string password = Console.ReadLine().Trim();

                            User user = User.ListOfUsers.Find(x => x.Username == username && x.Password == password);
                            if (user != null)
                            {
                                Console.WriteLine("User found, successful login.");
                                Console.WriteLine("====================================================================================================== \n");
                                Console.Clear();
                                return user;
                            }
                            return null;

                        case 2:
                            Console.WriteLine("Registration confirmed.");
                            Console.Write("Enter Username: ");
                            string username1 = Console.ReadLine().Trim();
                            Console.Write("Enter Password: ");
                            string password1 = Console.ReadLine().Trim();
                            Console.Write("Enter the amount of funds you want in your wallet: ");
                            decimal wallet = Convert.ToDecimal(Console.ReadLine());

                            User newUser = new User(username1, password1, wallet);
                            User.ListOfUsers.Add(newUser);
                            User.SaveUserData();
                            User.LoadUserData();

                            User userLogin = User.ListOfUsers.Find(x => x.Username == username1 && x.Password == password1);
                            if (userLogin != null)
                            {
                                Console.WriteLine("User successful registration, User found, successful login.");
                                Console.WriteLine("====================================================================================================== \n");
                                Console.Clear();
                                return userLogin;
                            }
                            return null;

                        case 3:
                            Console.WriteLine("Exit confirmed.");
                            Exit();
                            return null;

                        default:
                            Console.WriteLine("Choice unknown");
                            return null;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choice.");
                    Console.WriteLine("====================================================================================================== \n");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void ApplicationProcess(User user)
        {
            try
            {
                User mainUser = user;
                while (true)
                {
                    try
                    {
                        int choice = Menu();

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("View All Charities confirmed.");
                                break;

                            case 2:
                                SearchCharities();
                                break;

                            case 3:
                                Console.WriteLine("Donate confirmed.");
                                break;

                            case 4:
                                Console.WriteLine("Learn more confirmed.");
                                break;

                            case 5:
                                GiveFeedback();
                                break;

                            case 6:
                                Console.WriteLine("View Donation History confirmed.");
                                break;

                            case 7:
                                Console.WriteLine("Exit confirmed.");
                                Exit();
                                break;

                            default:
                                Console.WriteLine("Error occurred in menu selecting process.");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void LoadPersistentJsonData()
        {
            User.LoadUserData();
            CharityManager.LoadCharityData();
        }

        // Sub-menu for Searching Charities
        public static void SearchCharities()
        {
            try
            {
                Console.WriteLine("Search Charities Menu:");
                Console.WriteLine("1. Search by Name");
                Console.WriteLine("2. Search by Category");
                Console.WriteLine("3. Search by Location");
                Console.WriteLine("4. Back to Main Menu");

                Console.Write("\nEnter your choice: ");
                int searchChoice = Convert.ToInt32(Console.ReadLine());

                switch (searchChoice)
                {
                    case 1:
                        Console.Write("Enter Charity Name: ");
                        string name = Console.ReadLine().Trim();
                        break;

                    case 2:
                        Console.Write("Enter Charity Category: ");
                        string category = Console.ReadLine().Trim();
                        break;

                    case 3:
                        Console.Write("Enter Charity Location: ");
                        string location = Console.ReadLine().Trim();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Returning to Main Menu.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Sub-menu for Giving Feedback
        public static void GiveFeedback()
        {
            try
            {
                Console.WriteLine("Give Feedback Menu:");
                Console.WriteLine("1. Feedback on Charities");
                Console.WriteLine("2. Feedback on Donation Process");
                Console.WriteLine("3. General Feedback");
                Console.WriteLine("4. Back to Main Menu");

                Console.Write("\nEnter your choice: ");
                int feedbackChoice = Convert.ToInt32(Console.ReadLine());

                switch (feedbackChoice)
                {
                    case 1:
                        Console.Write("Enter Charity Name for Feedback: ");
                        string charityName = Console.ReadLine().Trim();
                        // Implement feedback on charities logic
                        break;

                    case 2:
                        Console.Write("Enter Donation Process Feedback: ");
                        string donationFeedback = Console.ReadLine().Trim();
                        // Implement feedback on donation process logic
                        break;

                    case 3:
                        Console.Write("Enter General Feedback: ");
                        string generalFeedback = Console.ReadLine().Trim();
                        // Implement general feedback logic
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Returning to Main Menu.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
