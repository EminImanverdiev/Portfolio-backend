using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioBackend.Entities;

namespace PortfolioBackend.Repositories.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.ServiceId);

            builder.Property(s => s.ServiceTitle)
                .IsRequired()
                .HasMaxLength(400)
                .HasDefaultValue("Burada Service hissəsi haqqında ümumi məlumat verilməlidir");
            builder.Property(s => s.ServiceName)
                .IsRequired()
                .HasMaxLength(200)
                .HasDefaultValue("Servisinizin adi buraya daxil edlmelidir");
            builder.Property(s => s.ServiceContent)
                .IsRequired()
                .HasMaxLength(200)
                .HasDefaultValue("Servisinizin  haqqinda qisa sekilde yazilmalidir");

        }
    }
}
