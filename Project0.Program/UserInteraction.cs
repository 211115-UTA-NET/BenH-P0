namespace Project0.Tests{

    public class UserInteraction{

        public void promptAddCust(){

            string firstName = " ";
            string lastName = " ";
            Console.WriteLine("Enter the first name of the customer: ");
            firstName = Console.ReadLine();

            Console.WriteLine("Enter the last name of the customer: ");
            lastName = Console.ReadLine();

            //AddNewCustomer(firstName, lastName);

        }
    }
}