using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TravelClient.Models
{
  public class TravelClientContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Travel> Travels { get; set; }

    public TravelClientContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}