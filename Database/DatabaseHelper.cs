namespace EmergencyServices
{
    using System.Configuration;

    using System.Data.SqlClient;

    public class EmergencyServicesDB
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private static SqlConnection connection = new SqlConnection(ConnectionString);

        public static void CreateTableTableUsers()
        {
            // check if the table exists
            string sql = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                            BEGIN
                                CREATE TABLE Users (
                                UserIdentityNumber varchar(50) NOT NULL PRIMARY KEY, 
                                UserName varchar(50),
                                UserGender int,
                                UserAddress varchar(50)
                                )
                            END";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void CreateTableHistories()
        {
            // check if the table exists
            string sql = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Histories' AND xtype='U')
                            BEGIN
                                CREATE TABLE Histories (
                                HistoryID int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
                                ServiceType varchar(50),
                                Request datetime , 
                                UserIdentityNumber varchar(50) NOT NULL,
                                FOREIGN KEY (UserIdentityNumber) REFERENCES Users(UserIdentityNumber)
                                )
                            END";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void InsertUser(User user)
        {
            string sql = @"INSERT INTO Users (UserIdentityNumber, UserName, UserGender, UserAddress) VALUES (@UserIdentityNumber, @UserName, @UserGender, @UserAddress)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@UserIdentityNumber", user.IdentityNumber);
                command.Parameters.AddWithValue("@UserName", user.Name);
                command.Parameters.AddWithValue("@UserGender", user.Gender);
                command.Parameters.AddWithValue("@UserAddress", user.Address);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void InsertHistory(History history)
        {
            string sql = @"INSERT INTO Histories (ServiceType, Request, UserIdentityNumber) VALUES (@ServiceType, @Request, @UserIdentityNumber)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ServiceType", history.ServiceType);
                command.Parameters.AddWithValue("@Request", history.Request);
                command.Parameters.AddWithValue("@UserIdentityNumber", history.user.IdentityNumber);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void SelectAllHistories()
        {
            string sql = @"SELECT * FROM Histories";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3}", reader[0], reader[1], reader[2], reader[3]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void SelectWhichService(string ServiceType)
        {

            string sql = @"SELECT u.UserIdentityNumber,u.UserName,u.UserGender,u.UserAddress,h.Request,h.ServiceType 
                            FROM Users as u
                            INNER JOIN Histories as h ON u.UserIdentityNumber = h.UserIdentityNumber
                            WHERE h.ServiceType=@ServiceType";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ServiceType", ServiceType);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", reader[0], reader[1], reader[2], reader[3],reader[4]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void SelectPoliceService(int gender=10)
        {
            string sql = @"SELECT u.UserIdentityNumber,u.UserName,u.UserGender,u.UserAddress,h.Request,h.ServiceType 
                            FROM Users as u
                            INNER JOIN Histories as h ON u.UserIdentityNumber = h.UserIdentityNumber
                            WHERE h.ServiceType='police' AND u.UserGender=@gender";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@gender", gender);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", reader[0], reader[1], reader[2], reader[3],reader[4]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // check if the user exists
        public static bool CheckUser(string UserIdentityNumber)
        {
            string sql = @"SELECT * FROM Users WHERE UserIdentityNumber=@UserIdentityNumber";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@UserIdentityNumber", UserIdentityNumber);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        
    }
}