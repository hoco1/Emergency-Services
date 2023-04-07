namespace EmergencyServices
{
    public class Utility
    {
        public static void CreateTables()
        {
            EmergencyServicesDB.CreateTableTableUsers();
            EmergencyServicesDB.CreateTableHistories();
            // insert some data
            
            for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.IdentityNumber = "1234585247" + i;
                user.Name = "name" + i;
                user.Gender = i % 3;
                user.Address = "address" + i;
                EmergencyServicesDB.InsertUser(user);
                History history = new History();
                history.ServiceType = "medical";
                history.Request = DateTime.Now.AddDays(i);
                history.user = user;
                EmergencyServicesDB.InsertHistory(history);
            }
            
            for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.IdentityNumber = "1234585247" + i;
                user.Name = "name" + i;
                user.Gender = i % 3;
                user.Address = "address" + i;
                EmergencyServicesDB.InsertUser(user);
                History history = new History();
                history.ServiceType = "police";
                history.Request = DateTime.Now.AddDays(i);
                history.user = user;
                EmergencyServicesDB.InsertHistory(history);
            }

                        for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.IdentityNumber = "1234585247" + i;
                user.Name = "name" + i;
                user.Gender = i % 3;
                user.Address = "address" + i;
                EmergencyServicesDB.InsertUser(user);
                History history = new History();
                history.ServiceType = "fire";
                history.Request = DateTime.Now.AddDays(i);
                history.user = user;
                EmergencyServicesDB.InsertHistory(history);
            }

            

            
        }
        public static void FilterHistory()
        {
            Console.Clear();
            DisplayHistory();
            
            try
            {
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("All Services Provided");
                    EmergencyServicesDB.SelectAllHistories();
                    break;
                case 2:
                    Console.WriteLine("Fire Services");
                    EmergencyServicesDB.SelectWhichService("fire");
                    break;
                case 3:
                    Console.WriteLine("Emergency Services");
                    EmergencyServicesDB.SelectWhichService("medical");
                    break;
                case 4:
                    Console.WriteLine("Police Service For Men");
                    EmergencyServicesDB.SelectPoliceService(0);
                    break;
                case 5:
                    Console.WriteLine("Police Services For Women");
                    EmergencyServicesDB.SelectPoliceService(1);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public static void DisplayMenu(User user)
        {
            if (user == null)
                return;

            Console.WriteLine("Welcome to the Emergency Services");
            Console.WriteLine("Please select the service you need");
            Console.WriteLine($"{(int)MenuList.Theft}. Theft");
            Console.WriteLine($"{(int)MenuList.Fire}. Fire");
            Console.WriteLine($"{(int)MenuList.ShortnessOfBreath}. Shortness of breath");
            Console.WriteLine($"{(int)MenuList.History}. History");

            Console.WriteLine($"{(int)MenuList.Exit}. Exit");
            Console.WriteLine("Enter Option");
        }
        public static void DisplayHistory()
        {
            Console.WriteLine("Please select which history you want to view");
            Console.WriteLine($"{(int)HistoryList.AllServicesProvided}. All Services Provided");
            Console.WriteLine($"{(int)HistoryList.FireServices}. Fire Services");
            Console.WriteLine($"{(int)HistoryList.EmergencyServices}. Emergency Services");
            Console.WriteLine($"{(int)HistoryList.PoliceServiceForMen}. Police Service For Men");
            Console.WriteLine($"{(int)HistoryList.PoliceServicesForWomen}. Police Service For Women");

            Console.WriteLine($"{(int)HistoryList.Exit}. Exit");
            Console.WriteLine("Enter Option");
        }


        public static bool CheckAttempts(int attempt,int maxAttempts)
        {
            if (attempt >= maxAttempts)
            {
                Console.WriteLine("You have exceeded the maximum number of attempts");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static User GetInformation(int maxAttempts=3)
        {
            Console.Clear();
            string name = "";
            int attempt = 0;
            do
            {
                Console.WriteLine("Please enter your name (only letters)");
                name = Console.ReadLine();
                if (!Validator.ValidateName(name))
                {
                    Console.WriteLine("Invalid name");
                    attempt++;
                }

            } while (!Validator.ValidateName(name) && attempt < maxAttempts);
            if(CheckAttempts(attempt,maxAttempts))
                return null;
            
            int gender = 10;
            attempt = 0;
            do
            {
                Console.WriteLine("Please enter your gender (0 male , 1 female, 2 other)");
                try
                {
                    gender = Convert.ToInt32(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if(!Validator.ValidateGender(gender))
                {
                    Console.WriteLine("Invalid gender");
                    attempt++;
                }
                    
            } while (!Validator.ValidateGender(gender) && attempt < maxAttempts);
            if(CheckAttempts(attempt,maxAttempts))
                return null;


            string identityNumber = "";
            attempt = 0;
            do
            {
                Console.WriteLine("Please enter your identity number (10 digits)");
                identityNumber = Console.ReadLine();

                if (EmergencyServicesDB.CheckUser(identityNumber))
                {
                    Console.WriteLine("Identity number already exists");
                }

                if (!Validator.ValidateIdentityNumber(identityNumber))
                {
                    Console.WriteLine("Invalid identity number");
                    attempt++;
                }

            } while (!Validator.ValidateIdentityNumber(identityNumber) && attempt < maxAttempts);
            if(CheckAttempts(attempt,maxAttempts))
                return null;

            string address = "";
            attempt = 0;
            do
            {
                Console.WriteLine("Please enter your address (only letters)");
                address = Console.ReadLine();
                if (!Validator.ValidateAddress(address))
                {
                    Console.WriteLine("Invalid address");
                    attempt++;
                }
            } while (!Validator.ValidateAddress(address) && attempt < maxAttempts);
            if(CheckAttempts(attempt,maxAttempts))
                return null;
            
            User user = new User(){Name=name,Gender=gender,IdentityNumber=identityNumber,Address=address};
            EmergencyServicesDB.InsertUser(user);
            return user;
        }
    }
}
