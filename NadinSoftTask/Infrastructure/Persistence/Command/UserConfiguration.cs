using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Command;
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(b => b.Email).IsUnique();
        builder.Property(b => b.Email)
            .IsRequired(false)
            .HasMaxLength(80);

        builder.Property(x => x.UserName).IsRequired().HasMaxLength(25);

        builder.Property(b => b.Password)
            .IsRequired()
            .HasMaxLength(25);
    }
}