using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAuthenticationServices.Domain.Entity;

namespace UserAuthenticationServices.Infrastructure.EntityTypeConfiguration;

public class UserContentFilesEntityTypeConfiguration : IEntityTypeConfiguration<UserContentFiles>
{
    public void Configure(EntityTypeBuilder<UserContentFiles> builder)
    {
        builder.ToTable("user_content_files");

        builder.HasKey(x => x.FileId);

        builder.Property(x => x.FileId)
            .IsRequired();
        
        builder.Property(x => x.UserId)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.FileContent)
            .IsRequired();
        
        builder.Property(x => x.FileName)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .IsRequired(false);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserContentFiles)
            .HasForeignKey(x => x.UserId);

    }
}