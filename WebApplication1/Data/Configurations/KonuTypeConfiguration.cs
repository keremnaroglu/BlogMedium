using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations
{
    public class KonuTypeConfiguration : IEntityTypeConfiguration<Konu>
    {
        public void Configure(EntityTypeBuilder<Konu> builder)
        {
            builder .HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();

            builder.Property(x => x.KonuAdi).HasMaxLength(50);

            builder.HasMany(x => x.Makaleler).WithMany(x => x.Konular);
        }
    }
}
