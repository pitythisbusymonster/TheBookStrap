using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheBookStrap.Models
{
    public class Agenda
    {
        //AgendaID
        //AgendaOwner
        //AgendaDate
        //MorningText
        //AfternoonText
        //EveningText
        //NotesText

        //SixAm
        //SevenAM
        //EightAM
        //NineAM
        //TenAM
        //ElevenAM
        //Noon
        //OnePM
        //TwoPM
        //ThreePM
        //FourPM
        //FivePM
        //SixPM
        //SevenPM
        //EightPM
        

        [Key]
        public int AgendaID { get; set; }

        public AppUser AgendaOwner { get; set; }

        public DateTime AgendaDate { get; set; }


        [Required(ErrorMessage = "Text is required.")]
        [StringLength(500, MinimumLength = 5,
            ErrorMessage = "An entry must be at least 5 characters, no more than 500 characters")]
        public string MorningText { get; set; }


        [Required(ErrorMessage = "Text is required.")]
        [StringLength(500, MinimumLength = 5,
        ErrorMessage = "An entry must be at least 5 characters, no more than 500 characters")]
        public string AfternoonText { get; set; }


        [Required(ErrorMessage = "Text is required.")]
        [StringLength(500, MinimumLength = 5,
        ErrorMessage = "An entry must be at least 5 characters, no more than 500 characters")]
        public string EveningText { get; set; }


        //[Required(ErrorMessage = "Text is required.")]  //NEED TO REMOVE THIS
        [StringLength(500, MinimumLength = 5,
        ErrorMessage = "An entry must be at least 5 characters, no more than 500 characters")]
        public string NotesText { get; set; }

    }
}
