using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma_Entity_Framework_Core.Data;
using Karma_Entity_Framework_Core.Model;

namespace Karma_Entity_Framework_Core.Backend
{
    public class AdminClient
    {
        // en metod för att skapa om och seeda databasen

        public static void CreateAndSeedDatabase()
        {
            using var ctx = new FoodRescue();
            ctx.Database.EnsureDeleted();

            ctx.Database.EnsureCreated();
            ctx.Seed();
        }

        // en metod för att se alla användare

        public static List<object> SeeAllUsers()
        {
            using var ctx = new FoodRescue();

            var q = ctx.customers
                .Select(i => new
                {
                    i.Fullname,
                    i.Email,
                    i.Phone_Number
                });
            var list = new List<object>();

            foreach (var C in q)
            {
                Console.WriteLine($"\nName: {C.Fullname}, " +
                                  $"\nEmail:{C.Email}, " +
                                  $"\nPhone number: {C.Phone_Number}");

                list.Add(C);
            }
            return list;
        }

        // en metod för att kunna ta bort en användare utifrån användarnamn

        public static int EraseUser(int user)
        {
            using var ctx = new FoodRescue();

            ctx.customers.Remove(ctx.customers.Find(user));
            ctx.SaveChanges();

            return user;
        }

        // en metod för att se alla restauranger

        public static List<object> SeeAllRestaurants()
        {
            using var ctx = new FoodRescue();

            var q = ctx.restaurants
                .Select(i => new
                {
                    i.Restaurant_Name,
                    i.Phone_Number,
                    i.City,
                    i.Adress,
                    i.Open_Hours
                });
            var list = new List<object>();

            foreach (var R in q)
            {
                Console.WriteLine($"\nName: {R.Restaurant_Name}, " +
                                  $"\nPhone Number:{R.Phone_Number}, " +
                                  $"\nCity: {R.City}, " +
                                  $"\nAddress: {R.Adress}," +
                                  $"\nOpen Hours: {R.Open_Hours}");

                list.Add(R);
            }
            return list;
        }

        //en metod för att kunna lägga till ett nytt restaurang objekt

        public static Restaurant AddANewRestaurant(string restaurantName, string adress, string city, string number, string open_Hours)
        {
            using var ctx = new FoodRescue();
            var newResturant = new Restaurant();
            newResturant.Restaurant_Name = restaurantName;
            newResturant.Adress = adress;
            newResturant.City = city;
            newResturant.Phone_Number = number;
            newResturant.Open_Hours = open_Hours;

            ctx.restaurants.Add(newResturant);
            ctx.SaveChanges();

            return newResturant;
        }

    }
}
