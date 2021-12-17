namespace Project0{

    using System.Data.SqlClient;
    
    public class Customer{

        internal string firstName{get; set;}
        internal string lastName {get; set;}
        
        //internal Guid id = Guid.NewGuid();

        internal List<Order> orderHistory = new List<Order>();
       

        public Customer(string firstName, string lastName){

            this.firstName = firstName;
            this.lastName = lastName;
           

        }

        // public void AddNewCustomer(string firstName, string lastName){

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