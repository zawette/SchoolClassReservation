using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.Id).HasColumnName("ReservationId");

            builder.HasOne(r => r.instructor)
                .WithMany(i => i.reservations)
                .HasForeignKey(r => r.instructorId);

            builder.HasOne(r => r.cours)
                .WithMany(e => e.reservations)
                .HasForeignKey(r => r.coursId);

            builder.HasOne(r => r.salle)
                .WithMany(e => e.reservations)
                .HasForeignKey(r => r.salleId);
        }
    }
}
