using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikaShop.Models
{
    public class Order
    {
        [Key]
        public int id_order { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime order_date { get; set; }

        public string note { get; set; }

        public int state { get; set; }

        [ForeignKey("ApplicationUsers")]
        public string ApplicationUserId { get; set; }
        public virtual User_Order ApplicationUser { get; set; }

        [ForeignKey("Delivery")]
        public int id_delivery { get; set; }

        public Delivery Delivery { get; set; }


    }

    public class User_Order : IdentityUser
    {
        public virtual Order Order { get; set; }
    }
}
