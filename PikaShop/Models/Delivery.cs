using System;
using System.ComponentModel.DataAnnotations;

namespace PikaShop.Models
{
    public class Delivery
    {
        [Key]
        public int id_delivery { get; set; }

        public string name_delivery { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime start_delivery { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime end_delivery { get; set; }

        public float price_delivery { get; set; }
    }
}
