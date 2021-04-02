using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikaShop.Models
{
    public class OrderDetail
    {
        [Key]
        public int id_order_detail { get; set; }

        public int quantity { get; set; }

        public float unit_price { get; set; }

        [ForeignKey("Product")]
        public int id_product { get; set; }

        public Product Product { get; set; }

        [ForeignKey("Order")]
        public int id_order { get; set; }

        public Order Order { get; set; }
    }
}
