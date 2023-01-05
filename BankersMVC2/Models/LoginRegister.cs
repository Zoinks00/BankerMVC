using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;//allows for data to be marked a required
using Microsoft.AspNetCore.Mvc;// used to remmotelly check Dbase
using System.ComponentModel.DataAnnotations.Schema;// allows use of NotMapped to prevent unwanted data added to Dbase

namespace BankersMVC2.Models
{
    public class LoginRegister
    {
        // idLogin not needed for now
        //public int idLogin { get; set; }
        
        //makes field for user email to be filled in required
        [Required(ErrorMessage ="Please enter an email address")]
        [EmailAddress]
        public int UserEmail { get; set; }

        [Required(ErrorMessage ="Please enter a password")]
        [DataType(DataType.Password)]        
        public string Password { get; set; }

        //varible to confirm password entered by user is same
        [Required(ErrorMessage = "Re-enter password to confirm")]
        [Display(Name = "Confirm your password")]
        //below code added to prevent confirmapss varible from being added to database
       //compare password enter to variable for confirmpass
        [Compare("Password", ErrorMessage = "Password and confirmation password are not the same.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
