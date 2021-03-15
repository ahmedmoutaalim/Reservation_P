using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Reservation_Std.Models
{

    [Table("tblType_Reservation")]
    public class Type_Reservation
    {
        [Key]
        public int IdType_reservation { get; set; }
        public string Nom { get; set; }
        public int Number { get; set; }

    }
}
