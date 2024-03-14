using task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace task.contexts
{
    public class ProniaDbContext : IdentityDbContext<AppUser>
    {

        public ProniaDbContext(DbContextOptions<ProniaDbContext> options) : base(options)
        {

        }
        public DbSet<Shipping>? Shippings { get; set; }
        public DbSet<product> Products { get; set; }
    }
}
