namespace Project0{

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

        

    }
}