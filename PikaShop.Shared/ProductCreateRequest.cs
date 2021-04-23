using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;


namespace PikaShop.Shared
{
    public class ProductCreateRequest
    {
        public string name_product { get; set; }

        public string image { get; set; }

        public IFormFile ThumbnailImage { get; set; }

        public float price { get; set; }

        public float height { get; set; }

        public float weight { get; set; }

        public int quantity { get; set; }

        public string description { get; set; }

        public int id_category { get; set; }

        public int id_brand { get; set; }
    }
}
