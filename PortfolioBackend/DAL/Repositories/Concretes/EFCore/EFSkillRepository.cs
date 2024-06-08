using PortfolioBackend.Core.DAL.Repositories.Concretes.EFCore;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities;
using PortfolioBackend.Repositories.EFcore;

namespace PortfolioBackend.DAL.Repositories.Concretes.EFCore
{
    public class EFSkillRepository : EfBaseRepository<Skill, AppDbContext>, ISkillRepository
    {
        public EFSkillRepository(AppDbContext context) : base(context)
        {
        }
    }
}
