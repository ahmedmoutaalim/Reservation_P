using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reservation_Std.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation_Std.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Type_Reservation> Type_Reservations { get; set; }
    }
}
