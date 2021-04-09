using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Shared
{
    public class RatingVm
    {
        public int id_rating { get; set; }

        public DateTime date { get; set; }

        public string comment { get; set; }

        public string id_user { get; set; }


        public int id_product { get; set; }

        public int totalStar { get; set; }

    }
}
