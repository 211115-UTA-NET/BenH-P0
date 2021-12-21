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

         public IEnumerable<String> listOrderDetailsOfCustomer(int customerID)
        {
            List<String> result = new();
            
            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = new(@"SELECT * FROM Invoice JOIN InvoiceLine ON Invoice.OrderID = InvoiceLine.OrderID AND CustomerId = @customerID;", connection);

            command.Parameters.AddWithValue("@customerID", customerID);

            using SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine($"Customer# {customerID} placed order {reader.GetInt32(0)} on {reader.GetDateTime(3)} ");
                result.Add(reader.GetInt32(0).ToString());
                
            }

            connection.Close();
            
            return result;

            
     
        }

        public IEnumerable<String> listOrderDetailsOfLocation(int locationID)
        {
            List<String> result = new();

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = new(@"SELECT * FROM Invoice JOIN InvoiceLine ON Invoice.OrderID = InvoiceLine.OrderID AND LocationID = @locationID;", connection);

            command.Parameters.AddWithValue("@locationID", locationID);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Location# {locationID} has order {reader.GetInt32(0)} on {reader.GetDateTime(3)} ");
                result.Add(reader.GetInt32(0).ToString());

            }

            connection.Close();

            return result;



        }

        public void decreaseStock(string locationID, string productID, int amount)
        {

            int locationStock = 0; 

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = new(@"SELECT Stock FROM LocationInventory WHERE LocationID = @locationID AND ProductID = @productID; ", connection);

            command.Parameters.AddWithValue("@locationID", locationID);
            command.Parameters.AddWithValue("@productID", productID);

            using SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            locationStock = reader.GetInt32(0);

            connection.Close();

            locationStock = locationStock - amount;

            connection.Open();
            
            using SqlCommand command2 = new(@"UPDATE LocationInventory SET Stock = @locationStock WHERE LocationID = @locationID AND ProductID = @productID; ", connection);

            command2.Parameters.AddWithValue("@locationID", locationID);
            command2.Parameters.AddWithValue("@productID", productID);
            command2.Parameters.AddWithValue("@locationStock", (int)locationStock);
            command2.ExecuteNonQuery();

            connection.Close();

        }

        public void addItemsToOrder(string orderID, string locationID, string productID, int quantity)
        {
            using SqlConnection connection = new(connectionString);


            connection.Open();

            if (checkStoreHasEnough(locationID, productID, quantity))
            {
                using SqlCommand command = new(@"INSERT INTO InvoiceLine (OrderID, ProductID, Quantity) VALUES (@orderID, @productID, @quantity); ", connection);
                command.Parameters.AddWithValue("@orderID", orderID);
                command.Parameters.AddWithValue("@productID", productID);
                command.Parameters.AddWithValue("@quantity", quantity);

                command.ExecuteNonQuery();

                connection.Close();
            }

            connection.Close();
        }

        public int getOrderIDFromDate(DateTime date)
        {

            using SqlConnection connection = new(connectionString);


            connection.Open();

            string cmdText = @"SELECT OrderID FROM Invoice WHERE OrderDate = @date;";


            using SqlCommand command = new(cmdText, connection);

            command.Parameters.AddWithValue("@date", date);

            using SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            int orderID = reader.GetInt32(0);

            connection.Close();

            return orderID;
        }

        public bool checkStoreHasEnough(string locationID, string productID, int quantity)
        {
            int locationStock = 0;

            using SqlConnection connection = new(connectionString);

            connection.Open();

            using SqlCommand command4 = new(@"SELECT Stock FROM LocationInventory WHERE LocationID = @locationID AND ProductID = @productID; ", connection);

            command4.Parameters.AddWithValue("@locationID", locationID);
            command4.Parameters.AddWithValue("@productID", productID);

            using SqlDataReader reader2 = command4.ExecuteReader();

            reader2.Read();

            locationStock = reader2.GetInt32(0);

            connection.Close();

            if (locationStock < quantity)
            {
                Console.WriteLine("Location does not have enough inventory for that order");
                return false;
            }

            else
            {
                return true;
            }
        }
        
        
        public void placeOrder(string customerID, string locationID, DateTime date, string productID, int quantity)
        {
         
            
            using SqlConnection connection = new(connectionString);


            if (checkStoreHasEnough(locationID, productID, quantity))
            {
             
                connection.Open();

                string cmdText = @"INSERT INTO Invoice (CustomerId, LocationId, OrderDate) VALUES (@customerID, @locationID, @date);";
                using SqlCommand command = new(cmdText, connection);

                command.Parameters.AddWithValue("@customerID", customerID);
                command.Parameters.AddWithValue("@locationID", locationID);
                command.Parameters.AddWithValue("@date", date);

                command.ExecuteNonQuery();
                connection.Close();


                int orderID = getOrderIDFromDate(date);

                connection.Open();

                cmdText = @"INSERT INTO InvoiceLine (OrderID, ProductID, Quantity) VALUES (@orderID, @productID, @quantity);";

                using SqlCommand command3 = new(cmdText, connection);



                command3.Parameters.AddWithValue("@orderID", orderID);
                command3.Parameters.AddWithValue("@productID", productID);
                command3.Parameters.AddWithValue("@quantity", quantity);

                command3.ExecuteNonQuery();
                connection.Close();

                decreaseStock(locationID, productID, quantity);

            }
        }
    }
}