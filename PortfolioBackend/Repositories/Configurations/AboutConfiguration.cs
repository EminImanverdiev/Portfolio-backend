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
                .HasDefaultValue("System Admin")
                .HasColumnType(SqlDbType.NVarChar.ToString());

        }
    }
}
