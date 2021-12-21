namespace Project0.Program {

    using System.Data.SqlClient;
    using Project0.DB;


    public class Program {

       public static string connectionString = File.ReadAllText("../../ben-db-connection-string.txt");

       public static void Main(string[] args)
        {
            DBInteraction cmd = new DBInteraction(connectionString);

            cmd.getOrderDetails(12);
        }



        
        

        public static void AddCustomerConsole(DBInteraction cmd)
        {
            string? firstName;
            string? lastName;
            Console.WriteLine("Enter customer first name");

            firstName = Console.ReadLine();

            Console.WriteLine("Enter customer last name");

            lastName = Console.ReadLine();


            cmd.AddNewCustomer(firstName ?? "INVALID ENTRY", lastName ?? "INVALID ENTRY");

            Console.WriteLine($"{firstName} {lastName} added to database");
            
            
        }

        public static void AddLocationConsole(DBInteraction cmd)
        {
            string? storeName;
            
            Console.WriteLine("Enter Location Name");

            storeName = Console.ReadLine();

            
            cmd.AddNewLocation(storeName ?? "INVALID ENTRY");

            Console.WriteLine($"{storeName} added to database");


        }

        public static void PlaceOrderConsole(DBInteraction cmd)
        {

            Console.WriteLine("Enter Customer ID: ");
            string? customerID = Console.ReadLine();
            Console.WriteLine("Enter location ID: ");
            string? locationID = Console.ReadLine();
            Console.WriteLine("Enter Product ID: ");
            string? productID = Console.ReadLine();
            Console.WriteLine("Enter Quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());

            cmd.placeOrder(customerID, locationID, DateTime.Now, productID, quantity);
        }

        public static void ListLocationOrderConsole(DBInteraction cmd)
        {

            Console.WriteLine("Enter the ID of the Location you would like to view the order history of");
            int locID = Convert.ToInt32(Console.ReadLine());

            cmd.listOrderDetailsOfLocation(locID);
        }

        public static void ListCustomerOrderConsole(DBInteraction cmd)
        {

            Console.WriteLine("Enter the ID of the Customer you would like to view the order history of");
            int custID = Convert.ToInt32(Console.ReadLine());

            cmd.listOrderDetailsOfCustomer(custID);
        }

        public static void ListOrderDetailsConsole(DBInteraction cmd)
        {
            Console.WriteLine("Enter the OrderID of the order");
            int orderId = Convert.ToInt32(Console.ReadLine());

            cmd.getOrderDetails(orderId);
        }

        public static void FindCustomerConsole(DBInteraction cmd)
        {
            Console.WriteLine("Enter the first name followed by the last name");

            string? firstName = Console.ReadLine();  
            string? lastName = Console.ReadLine();

            cmd.findCustomer(firstName, lastName);
        }



    }
    

}
