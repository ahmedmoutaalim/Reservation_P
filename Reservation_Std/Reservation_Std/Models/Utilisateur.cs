using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Reservation_Std.Models
{
   
    public class Utilisateur : IdentityUser
    {
        
        public int ID_Utilisateur { set; get; }
        [Display (Name = "Firstname")]
        public string Nom { get; set; }
        [Display(Name = "Lastname")]
        public string Prenom { get; set; }
        [Display(Name = "User Email")]
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email_Utilisateur { get; set; }
        public int Nombre_reservation { get; set; }

    }
}
