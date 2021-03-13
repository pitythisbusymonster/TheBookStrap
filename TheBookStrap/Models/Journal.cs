using System;
using System.ComponentModel.DataAnnotations;


namespace TheBookStrap.Models
{
    public class Journal
    {
        //JournalID
        //Journalist
        //EntryText
        //EntryDate
        //EntryStatus

        [Key]
        public int JournalID { get; set; }   //should be "EntryID"


        public AppUser Journalist { get; set; }


        [Required(ErrorMessage = "Text is required to create a journal entry.")]
        [StringLength(2000, MinimumLength = 10,
            ErrorMessage = "A journal entry must be at least 10 to 2000 characters.")]
        public string EntryText { get; set; }


        public DateTime EntryDate { get; set; }

        public bool EntryStatus { get; set; }

    }
}
