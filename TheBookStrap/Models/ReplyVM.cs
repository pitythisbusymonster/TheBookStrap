using System.ComponentModel.DataAnnotations;


namespace TheBookStrap.Models
{
    public class ReplyVM
    {
        public int PostID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string PostTitle { get; set; }
        public string ReplyText { get; set; }
    }
}
