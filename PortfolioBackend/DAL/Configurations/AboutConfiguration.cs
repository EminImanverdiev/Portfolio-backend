using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioBackend.Entities;
using System.Data;

namespace PortfolioBackend.Repositories.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(a => a.Content)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(a => a.SubContent)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a=>a.Birthday)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a=>a.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a=>a.Phone)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Age)
                .IsRequired();
            builder.Property(a=>a.Degree)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(a=>a.Website)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(a=>a.Freelance)
                .IsRequired()
                .HasMaxLength(50); 
        }
    }
}
