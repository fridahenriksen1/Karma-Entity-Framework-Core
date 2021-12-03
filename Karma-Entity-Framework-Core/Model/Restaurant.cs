using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma_Entity_Framework_Core.Model
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        public string Restaurant_Name { get; set; }
        public string City { get; set; }
        public string Phone_Number { get; set; }
        public string Adress { get; set; }
        public string Open_Hours { get; set; }

        //FK
        public virtual ICollection<Food_Package> FoodPackages { get; set; }

    }
}
