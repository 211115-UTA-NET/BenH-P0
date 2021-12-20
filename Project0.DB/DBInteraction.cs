namespace Project0.DB{

    using System.Data.SqlClient;

    using Project0.App;
    using System.Linq;

    public class DBInteraction : IDBCommands
    {


        private readonly string connectionString;
        public DBInteraction(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }


        public void AddNewCustomer(string firstName, string lastName)
        {

            using SqlConnection connection = new(connectionString);
            connection.Open();

            string cmdText = @"INSERT INTO Customer (firstName, lastName) VALUES (@firstName, @lastName);";
            using SqlCommand command = new(cmdText, connection);

            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            command.ExecuteNonQuery();
            connection.Close();

        }

        public void AddNewLocation(string storeName)
        {

            using SqlConnection connection = new(connectionString);

            connection.Open();

            string cmdText = @"INSERT INTO Location (LocationName) VALUES (@storeName);";
            using SqlCommand command = new(cmdText, connection);

            command.Parameters.AddWithValue("@storeName", storeName);

            command.ExecuteNonQuery();
            connection.Close();

        }

        public IEnumerable<Customer> findCustomer(string firstName, string lastName)
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
                result.Add(new(reader.GetString(1), reader.GetString(2)));
                Console.WriteLine($"Customer {firstName} {lastName} found with ID {reader.GetInt32(0)}");
            }

            connection.Close();

            return result;

        }

        public void listOrderDetailsOfCustomer(string customerID)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command2 = new(@"SELECT firstName, lastName FROM Customer WHERE CustomerID = @customerID;", connection);

            using SqlDataReader reader2 = command2.ExecuteReader();

            string firstName = reader2.GetString(0);
            string lastName = reader2.GetString(1);

            using SqlCommand command = new(@"SELECT * FROM Invoice WHERE CustomerID = @customerID INNER JOIN InvoiceLine 
                                            WHERE Invoice(OrderID) = InvoiceLine(OrderID)", connection);

            command.Parameters.AddWithValue("@customerID", customerID);

            using SqlDataReader reader = command.ExecuteReader();

            

            

            while (reader.Read())
            {
                Console.WriteLine();
            }
        }

        public void placeOrder(string customerID, string locationID, DateTime date, string productID, string quantity)
        {
            using SqlConnection connection = new(connectionString);

            connection.Open();

            string cmdText = @"INSERT INTO Invoice (CustomerId, LocationId, OrderDate) VALUES (@customerID, @locationID, @date);";
            using SqlCommand command = new(cmdText, connection);

            command.Parameters.AddWithValue("@customerID", customerID);
            command.Parameters.AddWithValue("@locationID", locationID);
            command.Parameters.AddWithValue("@date", date);

            command.ExecuteNonQuery();
            connection.Close();

            connection.Open();

            cmdText = @"SELECT OrderID FROM Invoice WHERE OrderDate = @date;";

            
            using SqlCommand command2 = new(cmdText, connection);

            command2.Parameters.AddWithValue("@date", date);

            using SqlDataReader reader = command2.ExecuteReader();

            reader.Read();

            int orderID = reader.GetInt32(0);

            connection.Close();

            connection.Open();

            cmdText = @"INSERT INTO InvoiceLine (OrderID, ProductID, Quantity) VALUES (@orderID, @productID, @quantity);";

            using SqlCommand command3 = new(cmdText, connection);

            

            command3.Parameters.AddWithValue("@orderID", orderID);
            command3.Parameters.AddWithValue("@productID", productID);
            command3.Parameters.AddWithValue("@quantity", quantity);

            command3.ExecuteNonQuery();
            connection.Close();
        }
    }
}