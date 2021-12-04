using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma_Entity_Framework_Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Karma_Entity_Framework_Core.Data
{
    public class FoodRescue : DbContext
    {
        public FoodRescue()
        {

        }

        public FoodRescue(DbContextOptions<FoodRescue> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> customers { get; set; }
        public virtual DbSet<Restaurant> restaurants { get; set; }
        public virtual DbSet<Food_Package> food_packages { get; set; }
        public virtual DbSet<Order> orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => new
                {
                    c.Email,
                    c.Username,
                    c.Phone_Number
                }).IsUnique();

            modelBuilder.Entity<Restaurant>()
                .HasIndex(c => new
                {
                    c.Restaurant_Name
                }).IsUnique();

            modelBuilder.Entity<Food_Package>()
                .HasIndex(c => new
                {
                    c.Dish
                }).IsUnique();

            modelBuilder.Entity<Order>()
                .HasIndex(c => new
                {
                    c.UserEmail,
                    c.OrderID
                }).IsUnique();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .LogTo(m => Debug.WriteLine(m), LogLevel.Information)
                    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=FoodRescue");
            }
        }

        public void Seed()
        {
            var customer = new Customer[]
            {

                new() {Fullname = "Frida Henriksen", Email = "fridahenriksen1@gmail.com", Username = "Fritjof", Password = "Lucy123", Phone_Number = "0729025435",},
                new() {Fullname = "Hedda Svensson", Email = "hedda1@hotmail.com", Username = "Hedda1", Password = "Hund123", Phone_Number = "0785432674"},
                new() {Fullname = "Maja Erlandsson", Email = "Maja12@gmail.com", Username = "Majsan", Password = "Katt123", Phone_Number = "0729025435"},
                new() {Fullname = "Malou Gustavsson", Email = "Maloug@gmail.com", Username = "MalouBalue", Password = "Godis123", Phone_Number = "0729025434"}

            };
            this.customers.AddRange(customer);

            var restaurant1 = new Restaurant[]
            {
                new() {Restaurant_Name = "Nami", City = "Varberg", Phone_Number = "0340205070", Adress = "Västra vallgatan 2", Open_Hours = "Mån-Fre kl.17-22"},
                new() {Restaurant_Name = "Subway", City = "Varberg", Phone_Number = "0763942203", Adress = "Kyrkogatan 1", Open_Hours = "Mån-Fre kl.09-19"},
                new() {Restaurant_Name = "Grappa", City = "Varberg", Phone_Number = "034017920", Adress = "Västra vallgatan 2", Open_Hours = "Mån-Lör kl.16-23"},
                new() {Restaurant_Name = "Veganen", City = "Varberg", Phone_Number = "0763942203", Adress = "Brunnsparken 8", Open_Hours = "Ons-Fre kl.12-15"}
            };
            this.restaurants.AddRange(restaurant1);
            var food_package = new Food_Package[]
            {
                new() {Dish = "Falafelrulle", Type_of_food = "Vego", Price = "85:-", Expiration_Date = DateTime.Today + TimeSpan.FromDays(6), Restaurants = restaurant1[3]},
                new() {Dish = "Kalops", Type_of_food = "Kött", Price = "95:-", Expiration_Date = DateTime.Today + TimeSpan.FromDays(4), Restaurants = restaurant1[2]},
                new() {Dish = "Sushi", Type_of_food = "Fisk", Price = "75:-", Expiration_Date = DateTime.Today + TimeSpan.FromDays(3),Restaurants = restaurant1[0]},
                new() {Dish = "Kycklingbaguette", Type_of_food = "Kött", Price = "50:-", Expiration_Date = DateTime.Today + TimeSpan.FromDays(8), Restaurants = restaurant1[1]},
                new() {Dish = "Toast Skagen", Type_of_food = "Fisk", Price = "70:-", Expiration_Date = DateTime.Today + TimeSpan.FromDays(2) ,Restaurants = restaurant1[0]},
                new() {Dish = "Sparrissoppa", Type_of_food = "Vego", Price = "75:-", Expiration_Date = DateTime.Today + TimeSpan.FromDays(4) ,Restaurants = restaurant1[3]},

            };
            this.food_packages.AddRange(food_package);
            var order1 = new Order[]
            {
                new() {UserEmail = "fridahenriksen@gmail.com", Delivery_Date = DateTime.Now + TimeSpan.FromMinutes(45), Customers = customer[0], FoodPackages = food_package[0]},
                new() {UserEmail = "hedda1@hotmail.com", Delivery_Date = DateTime.Now + TimeSpan.FromMinutes(50),  Customers = customer[1], FoodPackages = food_package[1]}
            };

            orders.AddRange(order1);
            this.SaveChanges();

        }


    }
}
