using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAuthenticationServices.Domain.Entity;

namespace UserAuthenticationServices.Infrastructure.EntityTypeConfiguration;

public class UserAuthorizationEntityTypeConfiguration : IEntityTypeConfiguration<UserAuthorization>
{
    public void Configure(EntityTypeBuilder<UserAuthorization> builder)
    {
        builder.ToTable("user_authorization");

        builder.HasKey(x => x.AuthorizationId);

        builder.Property(x => x.AuthorizationId)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.CreatedAd)
            .IsRequired();

        builder.HasOne(x => x.Users)
            .WithMany(x => x.UserAuthorizations)
            .HasForeignKey(x => x.UserId);
    }
}