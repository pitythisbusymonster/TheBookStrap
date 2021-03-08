using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheBookStrap.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Your name must be between 3 and 15 characters")]
        [Required]
        public string Name { get; set; }

        [NotMapped]   //won't add to db
        public IList<string> RoleNames { get; set; }
   
    }
}
