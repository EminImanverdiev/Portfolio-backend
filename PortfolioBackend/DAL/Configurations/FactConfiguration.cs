using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioBackend.Entities;

namespace PortfolioBackend.DAL.Configurations
{
    public class FactConfiguration : IEntityTypeConfiguration<Fact>
    {
        public void Configure(EntityTypeBuilder<Fact> builder)
        {
            builder.Property(f=>f.FactName)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue("Burada Faktinizin adini daxil etmelisiniz...");
        }
    }
}
