using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAuthenticationServices.Domain.Entity;

namespace UserAuthenticationServices.Infrastructure.EntityTypeConfiguration;

public class UserAuthenticationEntityTypeConfiguration : IEntityTypeConfiguration<UserAuthentication>
{
    public void Configure(EntityTypeBuilder<UserAuthentication> builder)
    {
        builder.ToTable("user_authentication");

        builder.HasKey(x => x.AuthenticationId);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.AuthenticationId)
            .IsRequired();

        builder.Property(x => x.Login)
            .IsRequired();

        builder.Property(x => x.Password)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserAuthentication)
            .HasForeignKey(x => x.UserId);
    }
}