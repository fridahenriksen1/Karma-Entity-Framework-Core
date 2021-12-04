using Karma_Entity_Framework_Core.Data;
using Karma_Entity_Framework_Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Karma_Entity_Framework_Core.Backend;

public class RestaurantClient
{
    // en metod för att få en lista över alla sålda matlådor för ett restaurang objekt
    public static List<object> ListForSoldFood_Packages()
    {
        using var ctx = new FoodRescue();

        var q = ctx.orders.OrderBy(i => i.FoodPackages)
            .Include(i => i.FoodPackages.Restaurants)
            .Select(i => new
            {
                i.FoodPackages.Restaurants.Restaurant_Name,
                i.OrderID,
                i.FoodPackages.Dish
            });

        var list = new List<object>();
        foreach (var F in q)
        {
            Console.WriteLine($"\nRestaurant: {F.Restaurant_Name}, " +
                              $"\nOrder:{F.OrderID}, " +
                              $"\nType of food: {F.Dish}");

            list.Add(F);
        }

        return list;
    }

    //en metod för att lägga till ett nytt matlådeobjekt för en restaurang
    public static Food_Package AddFood_PackagesToResturant(string dish, string typeOfFood, string price,
        DateTime ExpirationDate, int restaurant)
    {
        using var ctx = new FoodRescue();

        var newFoodPackage = new Food_Package();

        newFoodPackage.Dish = dish;
        newFoodPackage.Type_of_food = typeOfFood;
        newFoodPackage.Price = price;
        newFoodPackage.Expiration_Date = ExpirationDate;
        newFoodPackage.Restaurants = ctx.restaurants.Find(restaurant);

        ctx.food_packages.Add(newFoodPackage);
        ctx.SaveChanges();

        return newFoodPackage;
    }
}