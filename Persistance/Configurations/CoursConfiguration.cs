using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    class CoursConfiguration : IEntityTypeConfiguration<Cours>
    {
        public void Configure(EntityTypeBuilder<Cours> builder)
        {
            builder.Property(c => c.Id).HasColumnName("CoursId");
            builder.Property(c => c.designation).HasMaxLength(30);
        }
    }
}
