using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    class SalleConfiguration : IEntityTypeConfiguration<Salle>
    {
        public void Configure(EntityTypeBuilder<Salle> builder)
        {
            builder.Property(s => s.Id).HasColumnName("SalleId");
            builder.Property(s => s.designation).HasMaxLength(30);
            builder.HasIndex(s => s.designation).IsUnique(true);
            builder.HasMany(s => s.reservations).WithOne(r => r.salle).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
