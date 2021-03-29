using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservation_Std.Data;
using Reservation_Std.Models;

namespace Reservation_Std.Contract
{
    public interface IReservationRepository : IRepositoryBase<Reservation>
    {
        List<Reservation> GetReservationsByStudent(string id);
    }
}