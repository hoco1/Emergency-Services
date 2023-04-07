using EmergencyServices;
class Program
{
    static void Main(string[] args)
    {
        Utility.CreateTables();
        
        User user = Utility.GetInformation();
        
        EmergencyService emergencyService = new EmergencyService();
        EmergencyInvoker emergencyInvoker = new EmergencyInvoker();

        Console.Clear();

        while(true)
        {
            Utility.DisplayMenu(user);
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PoliceCommand policeCommand = new PoliceCommand(emergencyService);

                        // Calling police
                        emergencyInvoker.SetCommand(policeCommand);
                        emergencyInvoker.ExecuteCommand();

                        // add to history
                        History history = new History(){ServiceType = "police", Request = DateTime.Now, user = user};
                        EmergencyServicesDB.InsertHistory(history);
                        break;
                    case 2:
                        FirefightersCommand firefightersCommand = new FirefightersCommand(emergencyService);

                        // Calling firefighters
                        emergencyInvoker.SetCommand(firefightersCommand);
                        emergencyInvoker.ExecuteCommand();

                        // add to history
                        History history2 = new History(){ServiceType = "fire", Request = DateTime.Now, user = user};
                        EmergencyServicesDB.InsertHistory(history2);
                        break;
                    case 3:
                        AmbulanceCommand ambulanceCommand = new AmbulanceCommand(emergencyService);

                        // Calling ambulance
                        emergencyInvoker.SetCommand(ambulanceCommand);
                        emergencyInvoker.ExecuteCommand();

                        // add to history
                        History history3 = new History(){ServiceType = "medical", Request = DateTime.Now, user = user};
                        EmergencyServicesDB.InsertHistory(history3);
                        break;
                    case 4:
                        Utility.FilterHistory();
                        break;
                    case 5:
                        Console.Clear(); 
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear(); 
        }
    }
}