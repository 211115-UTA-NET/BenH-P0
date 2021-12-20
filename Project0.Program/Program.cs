namespace Project0.Program{
    
    using System.Data.SqlClient;
    using Project0.DB;
    using Project0.Program;
    
    public class Program{

        public static string connectionString = File.ReadAllText("ben-db-connection-string.txt");
        public static void Main(string[] args){




            DBInteraction cmd = new DBInteraction(connectionString);

            cmd.AddNewCustomer("Bahama", "LLL");
            
            
                
                
                
                 
            
        }

      
    }
    

}
