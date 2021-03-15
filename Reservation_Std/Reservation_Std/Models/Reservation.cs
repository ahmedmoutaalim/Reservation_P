using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reservation_Std.Models
{
    [Table("tblReservation")]
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public Type_Reservation ReservationType { get; set; }
        public bool IsValid { get; set; }

    }
}
