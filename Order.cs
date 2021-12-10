namespace Project0{

    class Order{

        protected string storeName;
        internal Dictionary<string, int> order = new Dictionary<string, int>();
        protected int customerId;
        private DateTime date = DateTime.Now;


        public Order(string storeName, int customerId)
        {
            this.storeName = storeName;
            this.customerId = customerId;
        }

        public void addToOrder(string product, int quantity){

            order.Add(product.ToLower(), quantity);
        }
        public void placeOrder(Location store, Dictionary<string, int> order){

            foreach(KeyValuePair<string, int> entry in order){
            
                if(!store.inventory.ContainsKey(entry.Key.ToLower()))
                {
                    Console.WriteLine($"Sorry, {store.storeName} does not have {entry.Key}.");
                }
                else if(entry.Value > 100)
                {
                    Console.WriteLine($"{store.storeName} does not accept orders that large.");
                }
                else if(entry.Value > store.inventory[entry.Key])
                {
                    Console.WriteLine($"{store.storeName} only has {store.inventory[entry.Key]} {entry.Key}s left.");
                }
                else
                {
                     Console.WriteLine($"Customer#{customerId} has successfully placed an order of {entry.Value} {entry.Key}s at {date}");
                     store.inventory[entry.Key] = store.inventory[entry.Key] - entry.Value;
                }
            }
        }




    }
}