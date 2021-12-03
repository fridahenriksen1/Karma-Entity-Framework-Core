using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma_Entity_Framework_Core.Data;
using Karma_Entity_Framework_Core.Model;

namespace Karma_Entity_Framework_Core.Backend
{
    public class UserClient
    {
        // en metod för att få ut en lista på alla oköpta matlådor i alla restauranger,
        // sorterade på pris lägst först. Parameter: typ av matlåda (kött/fisk/vego)
        public static List<object> UnpurchasedFood_Packages(string foodType)
        {
            using var ctx = new FoodRescue();

            var q = ctx.food_packages.OrderBy(i => i.Price)
                .Where(i => i.Type_of_food == foodType && i.Orders.Count == 0)
                .Select(i => new
                {
                    i.Dish,
                    i.Type_of_food,
                    i.Price,
                    Restaurant = i.Restaurants.Restaurant_Name
                });

            var list = new List<object>();

            foreach (var F in q)
            {

                Console.WriteLine($"Dish: {F.Dish}, " +
                                  $"Type of food:{F.Type_of_food}, " +
                                  $"Price: {F.Price}, " +
                                  $"Restaurant: {F.Restaurant}");
                list.Add(F);
            }

            return list;
        }


        //en metod för att köpa ett givet lunchlåde objekt.

        public static Order BuyAFood_Packages(int foodPackages, int customer, string email)
        {
            using var ctx = new FoodRescue();
            var newOrder = new Order();

            newOrder.FoodPackages = ctx.food_packages.Find(foodPackages);
            newOrder.Customers = ctx.customers.Find(customer);
            newOrder.UserEmail = email;
           // newOrder.Delivery_Date = deliveryDate;
            ctx.orders.Add(newOrder);
            ctx.SaveChanges();

            return newOrder;
        }


        public static List<object> SeeCustomersOrders(int id)
        {

            using var ctx = new FoodRescue();
            var q = ctx.orders
                .Where(i => i.FoodPackages.FoodID == id)
                .Select(i => new
                {
                    i.OrderID,
                    i.FoodPackages,
                    i.Customers,
                    i.Delivery_Date,
                    i.UserEmail

                });

            var list = new List<object>();
            foreach (var C in q)
            {
                
                Console.WriteLine($"Order id: {C.OrderID}, " +
                                  $"\nDish: {C.FoodPackages.Dish}, " +
                                  $"\nName: {C.Customers.Fullname}, " +
                                  $"\nEmail: {C.UserEmail}, " +
                                  $"\nDelivery date: {C.Delivery_Date}\n");
                
                list.Add(C);
            }

            return list;

        }


        public static List<object> SeeCustomersOrders2()
        {

            using var ctx = new FoodRescue();
            var q = ctx.orders
                //.Where(i => i.FoodPackages.FoodID == id)
                .Select(i => new
                {
                    i.OrderID,
                    i.FoodPackages,
                    i.Customers,
                    i.Delivery_Date,
                    i.UserEmail

                });

            var list = new List<object>();
            foreach (var C in q)
            {

                Console.WriteLine($"Order id: {C.OrderID}, " +
                                  $"\nDish: {C.FoodPackages.Dish}, " +
                                  $"\nName: {C.Customers.Fullname}, " +
                                  $"\nEmail: {C.UserEmail}, " +
                                  $"\nDelivery date: {C.Delivery_Date}\n");

                list.Add(C);
            }

            return list;

        }



    }
}
