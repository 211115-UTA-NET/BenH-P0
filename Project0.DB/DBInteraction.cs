namespace Project0.DB{

    using System.Data.SqlClient;
    public class DBInteraction : IDBCommands{

        public static string connectionString = File.ReadAllText("ben-db-connection-string.txt");

        public void AddNewCustomer(string firstName, string lastName){
                
                using SqlConnection connection = new(connectionString);
              
                connection.Open();
                using SqlCommand command = new(
                    $"INSERT INTO Customer (firstName, lastName) VALUES (@firstName, @lastName);",
                    connection);
                command.ExecuteNonQuery();
                connection.Close();

        }

        public void AddNewLocation(string storeName){

            using SqlConnection connection = new(connectionString);
              
                connection.Open();
                using SqlCommand command = new(
                    $"INSERT INTO Location (LocationName) VALUES (@storeName);",
                    connection);
                command.ExecuteNonQuery();
                connection.Close();
        }
    }
}