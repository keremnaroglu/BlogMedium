using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations
{
    public class KisiTypeConfiguration : IEntityTypeConfiguration<Kisi>
    {
        public void Configure(EntityTypeBuilder<Kisi> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();

            builder.Property(x => x.Ad).IsRequired().HasMaxLength(25);

            builder.Property(x => x.Soyad).IsRequired().HasMaxLength(25);

            builder.Property(x => x.Mail).IsRequired();

            builder.Property(x => x.Aciklama).HasMaxLength(300);

            builder.Property(x => x.Resim).IsRequired(false);

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Makaleler).WithOne(k => k.Kisi).HasForeignKey(k => k.KisiId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
