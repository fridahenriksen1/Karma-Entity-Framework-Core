// See https://aka.ms/new-console-template for more information

using System.Transactions;
using Karma_Entity_Framework_Core.Backend;
using Karma_Entity_Framework_Core.Data;

class Program
{
    static void Main(string[] args)
    {

        using var ctx = new FoodRescue();

        string userName = Environment.UserName;

        Console.WriteLine($"Welcome {userName}! :)");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();

        AdminClient.CreateAndSeedDatabase();


        bool myBool = true;

        while (myBool)
        {
            Console.WriteLine("1] Get a list of all unpurchased lunch boxes in all restaurants depending on the food type," +
                              " sorted by price lowest first");
            Console.WriteLine("2] Buy a lunch box");
            Console.WriteLine("3] List of all sold lunch boxes for a restaurant item");
            Console.WriteLine("4] Add a new lunch box item to a restaurant");
            Console.WriteLine("5] Re-create and seed the database");
            Console.WriteLine("6] Se all users");
            Console.WriteLine("7] Be able to delete a user based on user id");
            Console.WriteLine("8] See all restaurants");
            Console.WriteLine("9] Be able to add a new restaurant");
            Console.WriteLine("10] See a customer's order");
            Console.WriteLine("11] See all customers' orders");
            Console.WriteLine("12] Exit");


            Int32.TryParse(Console.ReadLine(), out int number);

            switch (number)
            {
                case 1:

                    Console.WriteLine("Enter what kind of food, for example Fisk/Kött/Vego:");
                    UserClient.UnpurchasedFood_Packages(Console.ReadLine());
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:
                    Console.WriteLine("Please add food id:");
                    int foodPackages = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter your customer id");
                    int customer = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter your email");
                    string email = Console.ReadLine();

                    UserClient.BuyAFood_Packages(foodPackages, customer, email);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;


                case 3:
                    RestaurantClient.ListForSoldFood_Packages();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 4:
                    Console.WriteLine("Dish:");
                    string dish = Console.ReadLine();
                    Console.WriteLine("Typ of food: ");
                    string typeOfFood = Console.ReadLine();
                    Console.WriteLine("Price: ");
                    string price = Console.ReadLine();
                    Console.WriteLine("Expiration date: ");
                    DateTime expirationDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Restaurant id");
                    int restaurantId = Convert.ToInt32(Console.ReadLine());

                    RestaurantClient.AddFood_PackagesToResturant(dish, typeOfFood, price, expirationDate, restaurantId);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 5:
                    AdminClient.CreateAndSeedDatabase();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;


                case 6:

                    AdminClient.SeeAllUsers();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 7:
                    Console.WriteLine("Enter customer id to delete user: ");
                    AdminClient.EraseUser(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("User is deleted!");
                    AdminClient.SeeAllUsers();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 8:

                    AdminClient.SeeAllRestaurants();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 9:

                    Console.WriteLine("Enter restaurant: ");
                    string reaturantName = Console.ReadLine();
                    Console.WriteLine("Enter address: ");
                    string adress = Console.ReadLine();
                    Console.WriteLine("Enter city: ");
                    string city = Console.ReadLine();
                    Console.WriteLine("Enter phone number: ");
                    string number1 = Console.ReadLine();
                    Console.WriteLine("Enter open hours: ");
                    string openHours = Console.ReadLine();


                    AdminClient.AddANewRestaurant(reaturantName, adress, city, number1, openHours);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 10:
                    
                    Console.WriteLine("Enter your customer id:");
                    int customerId = Convert.ToInt32(Console.ReadLine());
                    UserClient.SeeCustomersOrders(customerId);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 11:

                    UserClient.SeeCustomersOrders2();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 12:
                    myBool = false;

                    break;

                default:

                    Console.WriteLine("Please select an option! :)");

                    break;

            }

        }
    }

}
