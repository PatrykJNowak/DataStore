using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAuthenticationServices.Domain.Entity;

namespace UserAuthenticationServices.Infrastructure.EntityTypeConfiguration;

public class UserSessionsEntityTypeConfiguration : IEntityTypeConfiguration<UserSessions>
{
    public void Configure(EntityTypeBuilder<UserSessions> builder)
    {
        builder.ToTable("user_sessions");

        builder.HasKey(x => x.SessionId);
        
        builder.Property(x => x.SessionId)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.OpenedAt)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserSessions)
            .HasForeignKey(x => x.UserId);
    }
}