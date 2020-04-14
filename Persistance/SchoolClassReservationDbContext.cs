using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public class SchoolClassReservationDbContext : DbContext
    {
        public SchoolClassReservationDbContext(DbContextOptions<SchoolClassReservationDbContext> options):base(options)
        {
        }

        public DbSet<Reservation> reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolClassReservationDbContext).Assembly);
        }
    }
}
