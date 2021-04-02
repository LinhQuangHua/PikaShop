using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikaShop.Models
{
    public class RatingProduct
    {
        [Key]
        public int id_rating { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }

        public string comment { get; set; }

        [ForeignKey("ApplicationUsers")]
        public string ApplicationUserId { get; set; }
        public virtual User_RatingProduct ApplicationUser { get; set; }

        [ForeignKey("Product")]
        public int id_product { get; set; }

        public Product Product { get; set; }


    }
    public class User_RatingProduct : IdentityUser
    {
        public virtual RatingProduct RatingProduct { get; set; }
    }
}
