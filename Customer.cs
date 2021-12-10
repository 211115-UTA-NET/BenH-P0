namespace Project0{

    public class Customer{

        internal string name{get; set;}
        
        internal int customerId{get; set;}
       

        public Customer(string name, int customerId){

            this.name = name;
            this.customerId = customerId;

        }
    }
}