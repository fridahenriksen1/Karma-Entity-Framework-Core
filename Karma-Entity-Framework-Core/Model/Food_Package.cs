using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma_Entity_Framework_Core.Model
{
    public class Food_Package
    {
        [Key]
        public int FoodID { get; set; }
        public string Dish { get; set; }
        public string Type_of_food { get; set; }
        public string Price { get; set; }
        public DateTime Expiration_Date { get; set; }

        //FK
        public Restaurant Restaurants { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
