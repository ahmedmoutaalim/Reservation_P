using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation_Std.ViewModel
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Required (ErrorMessage = "Role name is required")]
        public string Name { get; set; }
        public List<string> Users { get; set; }

    }
}
