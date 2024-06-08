using PortfolioBackend.Core.DAL.Repositories.Concretes.EFCore;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities;
using PortfolioBackend.Repositories.EFcore;

namespace PortfolioBackend.DAL.Repositories.Concretes.EFCore
{
    public class EFFactRepository : EfBaseRepository<Fact, AppDbContext>, IFactRepository
    {
        public EFFactRepository(AppDbContext context) : base(context)
        {
        }
    }
}
