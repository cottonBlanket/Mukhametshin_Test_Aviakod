using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mukhametshin_Test_Aviakod.Domain.Entities;

namespace Mukhametshin_Test_Aviakod.DataAccess.Configuration;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Status).HasConversion<int>();
        builder.HasIndex(x => x.Status);
    }
}