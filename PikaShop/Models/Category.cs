using System.ComponentModel.DataAnnotations;
namespace PikaShop.Models
{
    public class Category
    {
        [Key]
        public int id_category { get; set; }

        public string name_category { get; set; }
    }
}
