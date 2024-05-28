using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioBackend.Entities;

namespace PortfolioBackend.DAL.Configurations
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.Property(t => t.TestimonialTitle)
                 .IsRequired()
                 .HasMaxLength(300);
            builder.Property(t => t.TestimonialContent)
                .IsRequired()
                .HasMaxLength(400);
            builder.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(t => t.Job)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
