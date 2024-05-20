using Microsoft.AspNetCore.Identity;

namespace PortfolioBackend.Entities.Auth
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
