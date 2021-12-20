namespace Project0.App{

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

        

        }
}
