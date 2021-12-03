using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma_Entity_Framework_Core.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string Fullname { get; set; }
        //[Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone_Number { get; set; }

        //Fk
        public virtual ICollection<Order> Orders { get; set; }
    }
}
