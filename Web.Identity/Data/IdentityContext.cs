using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Web.Identity.Data
{
    public class IdentityContext : IdentityDbContext
    {

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options) { }
    }
}
