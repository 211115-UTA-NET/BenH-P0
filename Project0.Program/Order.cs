namespace Project0{

    class Order{

        protected string storeName;
        internal Dictionary<string, int> order = new Dictionary<string, int>();
        protected Customer customer;
        protected Location store;
        private DateTime date = DateTime.Now;


        public Order(Location store, Customer customer)
        {
            this.store = store;
            this.customer = customer;
            customer.orderHistory.Add(this);
            store.orderHistory.Add(this);
        }

        public void addToOrder(string product, int quantity){

            order.Add(product.ToLower(), quantity);
        }
        public void placeOrder(){

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
                     Console.WriteLine($"{customer.firstName} {customer.lastName} has successfully placed an order of {entry.Value} {entry.Key}s at {date}");
                     store.inventory[entry.Key] = store.inventory[entry.Key] - entry.Value;
                     

                }
            }
        }




    }
}