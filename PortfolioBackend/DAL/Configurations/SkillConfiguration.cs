using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioBackend.Entities;

namespace PortfolioBackend.DAL.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.SkillId);

            builder.Property(s => s.SkillName)
                .IsRequired()
                .HasMaxLength(200)
                .HasDefaultValue("Burada Bacariginin adini daxil etmelisiniz...");
            builder.Property(s => s.SkillPercent).HasDefaultValue(0.0f);

        }
    }
}
