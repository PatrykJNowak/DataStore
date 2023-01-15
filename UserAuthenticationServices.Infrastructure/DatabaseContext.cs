using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UserAuthenticationServices.Domain.Entity;

namespace UserAuthenticationServices.Infrastructure;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserAuthorization> UserAuthorizations { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
}       