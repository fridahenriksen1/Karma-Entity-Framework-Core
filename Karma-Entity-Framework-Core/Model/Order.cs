using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma_Entity_Framework_Core.Model
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public DateTime Delivery_Date { get; set; }

        //Fk:s
        public Food_Package FoodPackages { get; set; }
        public Customer Customers { get; set; }

    }
}
