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
            } catch (Exception e)
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

            } catch (Exception ex)
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
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Login confirmed.");
                            Console.Write("Enter Username: ");
                            string username = Console.ReadLine().Trim();
                            Console.Write("Enter Password: ");
                            string password = Console.ReadLine().Trim();

                            User user = User.ListOfUsers.Find(x => x.Username == username && x.Password == password);
                            if(user != null)
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

                            User newUser = new User(username1, password1,wallet);
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
            }catch(Exception e)
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
                                Console.WriteLine("Search Charities confirmed.");
                                break;

                            case 3:
                                Console.WriteLine("Donate confirmed.");
                                break;

                            case 4:
                                Console.WriteLine("Learn more confirmed.");
                                break;

                            case 5:
                                Console.WriteLine("Give Feedback confirmed.");
                                break;

                            case 6:
                                Console.WriteLine("View Donation History confirmed.");
                                break;

                            case 7:
                                Console.WriteLine("Exit confirmed.");
                                Exit();
                                break;

                            default:
                                Console.WriteLine("Error occured in menu selecting process.");
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
    }
}
