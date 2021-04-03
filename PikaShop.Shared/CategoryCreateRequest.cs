using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Shared
{
    public class CategoryCreateRequest
    {
        [Required]
        public string name_category { get; set; }
    }
}
