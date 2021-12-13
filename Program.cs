namespace Project0{

    public class Program{

        public static void Main(string[] args){

                 Customer Ben = new Customer("Ben");
                 Customer Tyn = new Customer("Tyn");
                 Console.WriteLine(Ben.id.ToString());
                 Console.WriteLine(Tyn.id.ToString());
                // Location location = new Location("Lucharitos");
                // location.addInventory("Burritos", 500);
                // location.addInventory("tacos", 500);
                // location.addInventory("lettuCEs", 10);
                // location.addInventory("RancHes", 500);

                // Order burritoOrder = new Order("Lucharitos", 00001);
                // burritoOrder.addToOrder("Burritos", 20);
                // burritoOrder.addToOrder("tacos", 20);
                // burritoOrder.addToOrder("lettuces", 20);
                // burritoOrder.addToOrder("ranches", 200);
                // burritoOrder.addToOrder("ranchwwwes", 200);
                // burritoOrder.placeOrder(location, burritoOrder.order);

                // Console.WriteLine(location.inventory.GetValueOrDefault("burritos"));
            
        }
    

    }
}