using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Core.DAL.Repositories.Concretes.EFCore;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.Entities;
using PortfolioBackend.Repositories.EFcore;
using System.Linq.Expressions;

namespace PortfolioBackend.DAL.Repositories.Concretes.EFCore
{
    public class EFAboutRepository : EfBaseRepository<About, AppDbContext>,IAboutRepository
    {
        public EFAboutRepository(AppDbContext context) : base(context)
        {
        }
    }
}
