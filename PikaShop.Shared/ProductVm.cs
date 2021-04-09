using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Shared
{
    public class ProductVm
    {
        public int id_product { get; set; }

        public string name_product { get; set; }

        //public string image { get; set; }

        public string ThumbnailImageUrl { get; set; }


        public float price { get; set; }

        public float height { get; set; }

        public float weight { get; set; }

        public int quantity { get; set; }

        public string description { get; set; }

        public string name_category { get; set; }

        public string name_brand { get; set; }

        public int id_category { get; set; }


    }
}
