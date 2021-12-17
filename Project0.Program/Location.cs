namespace Project0.Program{

   
    using System.Data.SqlClient;
    class Location{

        internal string storeName;
        internal Dictionary<string, int> inventory = new Dictionary<string, int>();
        internal List<Order> orderHistory = new List<Order>();
        
        public Location(string storeName){

            this.storeName = storeName;
        }

        public void addInventory(string product, int quantity){

            inventory.Add(product.ToLower(), quantity);
        }

        // public void AddNewLocation(string firstName, string lastName){

        //     using SqlConnection connection = new(connectionString);
        //     connection.Open();
        //     using SqlCommand command = new(
        //         $"INSERT INTO Customers (FirstName, LastName) VALUES (@firstName, @lastName);",
        //         connection);
        //     command.Parameters.AddWithValue("@title", firstName);
        //     command.Parameters.AddWithValue("@pages", lastName);
        //     command.ExecuteNonQuery();
        //     connection.Close();
              
        //     Customer customer = new Customer(firstName, lastName);
        // }

        

    }
}