namespace Project0.Program{
    
    using System.Data.SqlClient;
    using Project
    public class Program{

        public static string connectionString = File.ReadAllText("ben-db-connection-string.txt");
        public static void Main(string[] args){

                string connectionString = File.ReadAllText("ben-db-connection-string.txt");


                using SqlConnection connection = new(connectionString);
              
                connection.Open();

        
                using SqlCommand command = new(
                    $"INSERT INTO Customer (firstName, lastName) VALUES (@firstName, @lastName);",
                    connection);
                command.Parameters.AddWithValue("@firstName", "Benjamin");
                command.Parameters.AddWithValue("@lastName", "Herbert");
                command.ExecuteNonQuery();
                connection.Close();

                Customer customer = new Customer("Benjamin", "Herbert");
                
                
                 
            
        }

      
    }
    

}
