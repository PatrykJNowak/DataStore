using Microsoft.EntityFrameworkCore;
using UserAuthenticationServices.Domain.Entity;

namespace UserAuthenticationServices.Infrastructure;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserSessions> UserSessions { get; set; }
    public DbSet<UserAuthentication> UserAuthentications { get; set; }
    public DbSet<UserContentFiles> UserContentFiles { get; set; }
    
    public DatabaseContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: move FK declaration to EntityTypeConfiguration directory 
        modelBuilder.Entity<UserSessions>().HasKey(x => x.SessionId);
        modelBuilder.Entity<User>().HasKey(x => x.UserId); 
        modelBuilder.Entity<UserAuthentication>().HasKey(x => x.AuthenticationId);
        modelBuilder.Entity<UserContentFiles>().HasKey(x => x.FileId);
    }
}       