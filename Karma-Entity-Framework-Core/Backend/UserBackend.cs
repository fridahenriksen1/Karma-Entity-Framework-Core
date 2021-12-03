using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma_Entity_Framework_Core.Data;
using Karma_Entity_Framework_Core.Model;

namespace Karma_Entity_Framework_Core.Backend
{
    public class UserBackend
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
                list.Add(F);
            }

            return list;
        }


        //en metod för att köpa ett givet lunchlåde objekt.

        public static Order BuyAFood_Packages(int foodPackages, int customer, string email, DateTime deliveryDate)
        {
            using var ctx = new FoodRescue();
            var newOrder = new Order();

            newOrder.FoodPackages = ctx.food_packages.Find(foodPackages);
            newOrder.Customers = ctx.customers.Find(customer);
            newOrder.UserEmail = email;
            newOrder.Delivery_Date = deliveryDate;
            ctx.orders.Add(newOrder);
            ctx.SaveChanges();

            return newOrder;
        }

    }
}
