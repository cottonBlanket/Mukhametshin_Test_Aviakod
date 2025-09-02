using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mukhametshin_Test_Aviakod.Domain.Entities;

namespace Mukhametshin_Test_Aviakod.DataAccess.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Username).IsUnique();
        builder.Property(x => x.Username).IsRequired().HasMaxLength(255);
        builder.Property(x => x.PasswordHash).IsRequired();
    }
}