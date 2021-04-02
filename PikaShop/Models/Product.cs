using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikaShop.Models
{
    public class Product
    {
        [Key]
        public int id_product { get; set; }

        public string name_product { get; set; }

        public string image { get; set; }

        public float price { get; set; }

        public float height { get; set; }

        public float weight { get; set; }

        public int quantity { get; set; }

        public string description { get; set; }

        [ForeignKey("Category")]
        public int id_category { get; set; }

        public Category Category { get; set; }

        [ForeignKey("Brand")]
        public int id_brand { get; set; }

        public Brand Brand { get; set; }



    }
}
