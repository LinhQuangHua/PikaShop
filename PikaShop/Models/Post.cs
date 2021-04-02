using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikaShop.Models
{
    public class Post
    {
        [Key]
        public int id_post { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public string description { get; set; }

        public string image_01 { get; set; }

        public string image_02 { get; set; }

        public string image_03 { get; set; }

        public int state { get; set; }

        [ForeignKey("Topic")]
        public int id_topic { get; set; }

        public Topic Topic { get; set; }
    }
}
