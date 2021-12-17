namespace Project0{
    
    using System.Data.SqlClient;
    public class Program{

        public static void Main(string[] args){

                string connectionString = File.ReadAllText("ben-db-connection-string.txt");


                using SqlConnection connection = new(connectionString);
              
                connection.Open();
                 //Customer Ben = new Customer("Ben");
                // Customer Tyn = new Customer("Tyn");
                 //Console.WriteLine(Ben.id.ToString());
                 //Console.WriteLine(Tyn.id.ToString());  
                 Location location = new Location("Lucharitos");
                 location.addInventory("Burritos", 500);
                 location.addInventory("tacos", 500);
                 location.addInventory("lettuCEs", 10);
                 location.addInventory("RancHes", 500);

                 Order burritoOrder = new Order(location, Tyn);
                 burritoOrder.addToOrder("Burritos", 20);
                 burritoOrder.addToOrder("tacos", 20);
                 burritoOrder.addToOrder("lettuces", 20);
                 burritoOrder.addToOrder("ranches", 200);
                 burritoOrder.addToOrder("ranchwwwes", 200);
                 burritoOrder.placeOrder();

                 //Console.WriteLine(Tyn.orderHistory.ElementAt(0).order["burritos"]);

                // Console.WriteLine(location.inventory.GetValueOrDefault("burritos"));
            
        }
    

    }
}