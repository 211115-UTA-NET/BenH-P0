namespace Project0.DB{

    using System.Data.SqlClient;
    using Project0.Program;
    using System.Linq;

    public class DBInteraction : IDBCommands{

        
        private readonly string connectionString;
        public DBInteraction(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        
        
        public void AddNewCustomer(string firstName, string lastName){
                
                using SqlConnection connection = new(connectionString);
                connection.Open();

                string cmdText = @"INSERT INTO Customer (firstName, lastName) VALUES (@firstName, @lastName);";
                using SqlCommand command = new(cmdText, connection);

                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                   
                command.ExecuteNonQuery();
                connection.Close();

        }

        public void AddNewLocation(string storeName){

            using SqlConnection connection = new(connectionString);
          
            connection.Open();

            string cmdText = @"INSERT INTO Customer (storeName) VALUES (@storeName);";
            using SqlCommand command = new(cmdText, connection);

            command.Parameters.AddWithValue("@storeName", storeName);
                   
            command.ExecuteNonQuery();
            connection.Close();           

        }

         public Inumerable<Customer> findCustomer(string firstName, string lastName)
        {

            List<Customer> result = new();

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = new(@"SELECT * FROM Customer WHERE firstName = @firstName AND lastName = @lastName", connection);

            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new(reader.GetString(1),reader.GetString(2)));
                Console.WriteLine($"Customer {firstName} {lastName} found with ID {reader.GetString(0)}");
            }

            connection.Close();

            return result;

        }
    }
}