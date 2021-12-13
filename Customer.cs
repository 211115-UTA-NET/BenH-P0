namespace Project0{

    public class Customer{

        internal string name{get; set;}
        
        internal Guid id = Guid.NewGuid();

        internal List<Order> orderHistory = new List<Order>();
       

        public Customer(string name){

            this.name = name;
           

        }
    }
}