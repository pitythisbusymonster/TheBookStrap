using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheBookStrap.Models
{
    public class CommunityBoard
    {
        //PostID
        //PostCreator
        //PostTitle
        //PostText
        //PostDate

        private List<Reply> replies = new List<Reply>();        //list object

        [Key]
        public int PostID { get; set; }


        public AppUser PostCreator { get; set; }


        [Required(ErrorMessage = "A page name is required")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Title must be between 3 and 20 characters")]
        public string PostTitle { get; set; }


        [Required(ErrorMessage = "Text is required to post")]
        [StringLength(200, MinimumLength = 10,
            ErrorMessage = "A post must be at least 10 characters and no more than 200 characters")]
        public string PostText { get; set; }


        public DateTime PostDate { get; set; }


        public List<Reply> Replies
        {
            get { return replies; }             //reply object, w/n list object
        }

    }
}
