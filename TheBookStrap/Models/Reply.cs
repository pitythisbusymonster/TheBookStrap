using System;
using System.ComponentModel.DataAnnotations;

namespace TheBookStrap.Models
{
    public class Reply
    {
        [Key]
        public int ReplyID { get; set; }
        public String ReplyText { get; set; }
        public DateTime ReplyDate { get; set; }
        public AppUser Replier { get; set; }
    }
}
