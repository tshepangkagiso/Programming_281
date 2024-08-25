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
        static void Main(string[] args)
        {
            try
            {
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
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }catch (Exception e)
            {
                Console.WriteLine(e);
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
                
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }

        public static void Exit()
        {
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
