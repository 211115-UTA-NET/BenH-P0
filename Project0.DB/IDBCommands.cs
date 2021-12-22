namespace Project0.DB{
    
    public interface IDBCommands{

        void AddNewCustomer(string firstName, string lastName);
        void AddNewLocation(string storeName);

        void placeOrder(string customerID, string locationID, DateTime date, string productID, int quantity);


        
    }
}