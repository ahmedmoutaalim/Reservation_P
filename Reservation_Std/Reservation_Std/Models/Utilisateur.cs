using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Reservation_Std.Models
{
    [Table("tblUtilisateur")]
    public class Utilisateur : IdentityUser
    {
        
        public int ID_Utilisateur { set; get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email_Utilisateur { get; set; }
        public int Nombre_reservation { get; set; }

    }
}
