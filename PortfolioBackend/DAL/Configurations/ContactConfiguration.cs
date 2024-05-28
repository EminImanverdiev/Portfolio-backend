using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioBackend.Entities;

namespace PortfolioBackend.DAL.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.ContactTitle)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(c => c.ContactEmail)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c=>c.ContactNumber)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c=>c.ContactLocation)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
