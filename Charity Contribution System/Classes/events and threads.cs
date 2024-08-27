using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CharityApp
{
    //EVENT HANDLING
    //The application will implement an event-driven architecture to handle significant user actions such as donations

    //• Donation Event: 
    //o Triggered in the Charity class whenever a donation is made.
    //o Includes information such as the donation amount, charity name, and donor’s name.
    //• Event Handler: 
    //o Located in the CharityManager class, responsible for logging donations and triggering
    //notifications.

    // EventArgs class to hold donation event data
    public class DonationEventArgs : EventArgs
    {
        public string CharityName { get; }
        public string DonorName { get; }
        public decimal Amount { get; }

        public DonationEventArgs(string charityName, string donorName, decimal amount)
        {
            CharityName = charityName;
            DonorName = donorName;
            Amount = amount;
        }
    }

    // Charity class
    public class Charity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        // Donation event declaration
        public event EventHandler<DonationEventArgs> DonationMade;

        public Charity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // Method to trigger the DonationMade event
        protected virtual void OnDonationMade(DonationEventArgs e)
        {
            DonationMade?.Invoke(this, e);
        }

        // Method to manage a donation made
        public void Donate(decimal amount, string donorName)
        {
            Console.WriteLine($"Thank you, {donorName}, for donating {amount:C} to {Name}.");

            // Trigger the donation event
            OnDonationMade(new DonationEventArgs(Name, donorName, amount));
        }
    }

    // CharityManager class to handle the Donation event
    public class CharityManager
    {
        // Event handler method
        public void OnDonationMade(object sender, DonationEventArgs e)
        {
            // Log the donation
            Console.WriteLine($"Logging donation: {e.DonorName} donated {e.Amount:C} to {e.CharityName}.");

            // Trigger notification
            Console.WriteLine($"Notification: A donation of {e.Amount:C} has been made to {e.CharityName} by {e.DonorName}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a charity
            Charity charity = new Charity("Global Health Initiative", "Supporting healthcare in underdeveloped regions.");

            // Create a CharityManager instance
            CharityManager manager = new CharityManager();

            // Subscribe to the DonationMade event
            charity.DonationMade += manager.OnDonationMade;

            // Make a donation
            charity.Donate(150m, "Jane Smith");
        }
    }




    //THREADS
    //To enhance performance and user experience, the application will employ multi-threading.
    //• Donation Processing: 
    //o Donations will be processed on separate threads, with simulated delays to represent transaction time



    namespace DonationProcessingApp
    {
        // Class representing a donation
        public class Donation
        {
            public string DonorName { get; set; }
            public double Amount { get; set; }

            public Donation(string donorName, double amount)
            {
                DonorName = donorName;
                Amount = amount;
            }

            // Method to process the donation, simulating a delay
            public void ProcessDonation()
            {
                Console.WriteLine($"Processing donation from {DonorName} of {Amount:C}...");
                // Simulate delay in processing the donation
                Thread.Sleep(3000); // Simulate a 3-second processing time
                Console.WriteLine($"Donation from {DonorName} of {Amount:C} processed successfully.");
            }
        }

        // Class responsible for managing donation processing using threads
        public class DonationProcessor
        {
            public void StartDonationProcessing(Donation donation)
            {
                // Start donation processing on a separate thread
                Thread donationThread = new Thread(new ThreadStart(donation.ProcessDonation));
                donationThread.Start();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                DonationProcessor processor = new DonationProcessor();

                // Example donations
                Donation donation1 = new Donation("Alice", 50);
                Donation donation2 = new Donation("Bob", 100);
                Donation donation3 = new Donation("Charlie", 75);

                // Process donations on separate threads
                processor.StartDonationProcessing(donation1);
                processor.StartDonationProcessing(donation2);
                processor.StartDonationProcessing(donation3);

                Console.WriteLine("Donations are being processed on separate threads...");
                Console.ReadLine(); // Prevent the application from closing immediately
            }
        }
    }




}


