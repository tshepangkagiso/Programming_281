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
                Console.Write("\nEnter Menu choice between 1 - 7");
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
                Console.WriteLine("Enter choice between 1 - 3 only");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 0)
                {
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Login confirmed.");
                            Console.WriteLine("Enter Username");
                            string username = Console.ReadLine().Trim();
                            Console.WriteLine("Enter Password");
                            string password = Console.ReadLine().Trim();
                            
                            User.LoadUserData();
                            CharityManager.LoadCharityData();
                            return null;

                        case 2:
                            Console.WriteLine("Registration confirmed.");
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
    }
}
