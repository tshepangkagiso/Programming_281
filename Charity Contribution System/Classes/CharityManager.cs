using Charity_Contribution_System.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json; // injected dependecy to use JsonSerializer
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Charity_Contribution_System.Classes
{
    //Manages the list of charities, including search functionality, adding new charities, and handling donations.
    internal class CharityManager : IDataPersistable
    {
        private const string ProjectName = "Charity Contribution System";
        private const string LocalStorageFolder = "LocalStorage";
        private const string FileName = "charities.json";

        public static List<SpecificCharity> ListOfCharities = new List<SpecificCharity>()
        {
            // Education
            new SpecificCharity("UNICEF", "Works to ensure every child can access quality education.", "Education", 10000.00m),
            new SpecificCharity("Room to Read", "Focuses on literacy and gender equality in education.", "Education", 8000.00m),
            new SpecificCharity("Save the Children", "Provides educational resources to children in need.", "Education", 7500.00m),
            new SpecificCharity("Teach For All", "Network of organizations aiming to expand educational opportunity.", "Education", 6500.00m),
            new SpecificCharity("Khan Academy", "Provides free online educational content to learners worldwide.", "Education", 9500.00m),
            new SpecificCharity("Scholarship America", "Helps students achieve their dreams of higher education.", "Education", 7200.00m),
            new SpecificCharity("The Education Trust", "Advocates for the high academic achievement of all students.", "Education", 6800.00m),
            new SpecificCharity("The Global Fund for Children", "Invests in innovative, community-based organizations helping children worldwide.", "Education", 8200.00m),
            new SpecificCharity("Pencils of Promise", "Builds schools and increases educational opportunities in developing countries.", "Education", 7000.00m),
            new SpecificCharity("The Luminos Fund", "Delivers a joyful, primary education to children denied the chance to learn.", "Education", 6700.00m),

            // Health
            new SpecificCharity("Doctors Without Borders", "Provides medical aid in crisis situations around the world.", "Health", 12000.00m),
            new SpecificCharity("American Cancer Society", "Dedicated to eliminating cancer as a major health problem.", "Health", 11000.00m),
            new SpecificCharity("The Red Cross", "Offers emergency assistance, disaster relief, and education worldwide.", "Health", 14000.00m),
            new SpecificCharity("St. Jude Children's Research Hospital", "Leading the way the world understands, treats, and defeats childhood cancer.", "Health", 15000.00m),
            new SpecificCharity("The Alzheimer's Association", "Leads the way to end Alzheimer's and all other dementia.", "Health", 9000.00m),
            new SpecificCharity("Project HOPE", "Provides healthcare and health education globally.", "Health", 10000.00m),
            new SpecificCharity("Partners In Health", "Provides healthcare to the poor and marginalized communities.", "Health", 12500.00m),
            new SpecificCharity("Mental Health America", "Promotes mental health as a critical part of overall wellness.", "Health", 8000.00m),
            new SpecificCharity("The Leukemia & Lymphoma Society", "The largest voluntary health organization dedicated to blood cancer.", "Health", 13500.00m),
            new SpecificCharity("Operation Smile", "Provides free surgeries to repair cleft lip, cleft palate, and other facial deformities for children around the globe.", "Health", 9500.00m),

            // Environment
            new SpecificCharity("World Wildlife Fund", "Works to conserve nature and reduce the most pressing threats to the diversity of life on Earth.", "Environment", 15000.00m),
            new SpecificCharity("Greenpeace", "Campaigns for environmental issues and against climate change.", "Environment", 13000.00m),
            new SpecificCharity("The Sierra Club", "Promotes the responsible use of the earth's ecosystems and resources.", "Environment", 11000.00m),
            new SpecificCharity("The Nature Conservancy", "Works to protect the lands and waters on which all life depends.", "Environment", 14000.00m),
            new SpecificCharity("Rainforest Alliance", "Works to conserve biodiversity and ensure sustainable livelihoods.", "Environment", 10000.00m),
            new SpecificCharity("Friends of the Earth", "A network that campaigns for environmental justice.", "Environment", 8000.00m),
            new SpecificCharity("Ocean Conservancy", "Works to protect the ocean from today's greatest global challenges.", "Environment", 12000.00m),
            new SpecificCharity("Earthjustice", "A nonprofit environmental law organization fighting for the protection of the environment.", "Environment", 9000.00m),
            new SpecificCharity("Environmental Defense Fund", "Addresses urgent threats to life on Earth, like climate change.", "Environment", 13000.00m),
            new SpecificCharity("350.org", "Works to end the age of fossil fuels and build a world of community-led renewable energy for all.", "Environment", 7500.00m),

            // Animal Welfare
            new SpecificCharity("The Humane Society of the United States", "Fights for the protection of all animals.", "Animal Welfare", 10000.00m),
            new SpecificCharity("ASPCA", "Works to rescue animals from abuse and pass humane laws.", "Animal Welfare", 11000.00m),
            new SpecificCharity("PETA", "Dedicated to establishing and defending the rights of all animals.", "Animal Welfare", 9000.00m),
            new SpecificCharity("Best Friends Animal Society", "Works to save them all by building no-kill communities.", "Animal Welfare", 12000.00m),
            new SpecificCharity("Wildlife Conservation Society", "Works to save wildlife and wild places worldwide.", "Animal Welfare", 10500.00m),
            new SpecificCharity("World Animal Protection", "Works to end the suffering of animals worldwide.", "Animal Welfare", 11500.00m),
            new SpecificCharity("Animal Welfare Institute", "Seeks to alleviate the suffering of animals caused by humans.", "Animal Welfare", 9500.00m),
            new SpecificCharity("International Fund for Animal Welfare", "Works to rescue and protect animals around the world.", "Animal Welfare", 10000.00m),
            new SpecificCharity("Humane Society International", "Works to protect all animals around the world.", "Animal Welfare", 9000.00m),
            new SpecificCharity("Animal Legal Defense Fund", "Works to protect the lives and advance the interests of animals through the legal system.", "Animal Welfare", 8500.00m),

            // Community Development
            new SpecificCharity("Habitat for Humanity", "Helps build and improve homes for families in need.", "Community Development", 14000.00m),
            new SpecificCharity("Heifer International", "Works to end hunger and poverty by providing livestock and training.", "Community Development", 13000.00m),
            new SpecificCharity("Oxfam", "Works to end the injustice of poverty.", "Community Development", 12000.00m),
            new SpecificCharity("CARE", "Fights global poverty and provides disaster relief.", "Community Development", 11000.00m),
            new SpecificCharity("United Way", "Fights for the health, education, and financial stability of every person in every community.", "Community Development", 10000.00m),
            new SpecificCharity("The Salvation Army", "Provides a wide array of social services worldwide.", "Community Development", 9000.00m),
            new SpecificCharity("Mercy Corps", "Helps people in the world's toughest places survive the crises they confront and turn them into opportunities for progress.", "Community Development", 15000.00m),
            new SpecificCharity("GlobalGiving", "Connects donors with grassroots projects around the world.", "Community Development", 8000.00m),
            new SpecificCharity("World Vision", "Helps the world's most vulnerable overcome poverty and experience fullness of life.", "Community Development", 13000.00m),
            new SpecificCharity("Build Change", "Works to save lives in earthquakes and windstorms by empowering people to live and learn in safe houses.", "Community Development", 12000.00m),
        };

        // Method to save changes to charities.json, that occured in ListOfCharities.
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
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                string jsonString = JsonSerializer.Serialize(ListOfCharities, options);
                File.WriteAllText(fullPath, jsonString);
                Console.WriteLine("Successfully saved data to charities.json");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Method to load existing list of charities.
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
                        PropertyNameCaseInsensitive = true,
                        ReferenceHandler = ReferenceHandler.Preserve
                    };
                    ListOfCharities = JsonSerializer.Deserialize<List<SpecificCharity>>(jsonString, options);
                    Console.WriteLine("Successfully loaded data from charities.json");
                }
                else
                {
                    // If file doesn't exist, initialize with default list and save
                    SaveData();
                    CharityManager.SaveCharityData();
                    Console.WriteLine("Initialized saved data locally and then loaded data from charities.json");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //Methods we call outside this call that reference internal methods.
        public delegate void data();
        public static void SaveCharityData()
        {
            Thread thread = new Thread(() =>
            {
                data SaveData = new CharityManager().SaveData;
                lock (ListOfCharities)
                {
                    SaveData.Invoke();
                }
            });

            thread.Start();
            thread.Join();

        }

        public static void LoadCharityData()
        {
            Thread thread = new Thread(() =>
            {
                data LoadData = new CharityManager().LoadData;
                lock (ListOfCharities)
                {
                    LoadData.Invoke();
                }
                
            });

            thread.Start();
            thread.Join();

        }

    }
}
