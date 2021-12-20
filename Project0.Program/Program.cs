namespace Project0.Program{
    
    using System.Data.SqlClient;
    using Project0.DB;
   
    
    public class Program{

        public static string connectionString = File.ReadAllText("ben-db-connection-string.txt");
        public static void Main(string[] args){




            DBInteraction cmd = new DBInteraction(connectionString);

            /*cmd.AddNewCustomer("Bahama", "LLL");

            cmd.findCustomer("Bahama", "LLL");

            
*/
            //cmd.AddNewLocation("Lucharitos");
          
            cmd.placeOrder("1", "1", DateTime.Now, "1", "20");
            
            
                
                
                
                 
            
        }

      
    }
    

}
