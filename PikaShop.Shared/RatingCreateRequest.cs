using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Shared
{
    public class RatingCreateRequest
    {
        public string comment { get; set; }

        public int id_product { get; set; }

        [Range(1, 5, ErrorMessage = "Please enter valid integer Number")]
        public int totalStar { get; set; }

    }
}
