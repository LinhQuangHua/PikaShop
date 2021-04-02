using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikaShop.Models
{
    public class CommentPost
    {
        [Key]
        public int id_comment { get; set; }

        public DateTime date_comment { get; set; }

        public string comment { get; set; }

        public int rating { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public virtual User_CommentPost ApplicationUser { get; set; }

        [ForeignKey("Post")]
        public int id_post { get; set; }

        public Post Post { get; set; }

    }

    public class User_CommentPost : IdentityUser
    {
        public virtual CommentPost CommentPost { get; set; }
    }
}
