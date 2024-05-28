using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioBackend.Entities;

namespace PortfolioBackend.DAL.Configurations
{
    public class ContactFormConfiguration : IEntityTypeConfiguration<ContactForm>
    {
        public void Configure(EntityTypeBuilder<ContactForm> builder)
        {
            builder.Property(c => c.ContactFormName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c=>c.ContactFormEmail)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c=>c.ContactFormSubject)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c=>c.ContactFormMessage)
                .IsRequired()
                .HasMaxLength(400);
        }
    }
}
