using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBackend.Domain.Users;

namespace SimpleBackend.Infrasturcture.Users;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(300)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}
