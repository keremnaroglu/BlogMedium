using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations
{
    public class MakaleTypeConfiguration : IEntityTypeConfiguration<Makale>
    {
        public void Configure(EntityTypeBuilder<Makale> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();

            builder.Property(x => x.Baslik).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Icerik).IsRequired().HasMaxLength(50);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Kisi).WithMany(a => a.Makaleler).HasForeignKey(x => x.KisiId);
        }
    }
}
