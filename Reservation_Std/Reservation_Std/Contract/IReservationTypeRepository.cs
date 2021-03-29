using Reservation_Std.Contract;
using Reservation_Std.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Reservation_Std.Contract
{
    public interface IReservationTypeRepository : IRepositoryBase<Type_Reservation>
    {
    }
}