using System.ComponentModel.DataAnnotations;

namespace PikaShop.Models
{
    public class Topic
    {
        [Key]
        public int id_topic { get; set; }

        public string name_topic { get; set; }
    }
}
