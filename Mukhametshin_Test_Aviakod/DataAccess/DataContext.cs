using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mukhametshin_Test_Aviakod.Domain.Entities;
using Mukhametshin_Test_Aviakod.Domain.Entities.Base;

namespace Mukhametshin_Test_Aviakod.DataAccess;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Issue> Issues { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        UseAutoTimeStamps();
    }


    private void UseAutoTimeStamps()
    {
        ChangeTracker.StateChanged += UpdateTimestamps;
        ChangeTracker.Tracked += UpdateTimestamps;
    }
    
    private static void UpdateTimestamps(object? sender, EntityEntryEventArgs e)
    {
        var entry = e.Entry;
        var entity = entry.Entity;

        switch (entry.State)
        {
            case EntityState.Modified when entity is IEntityModified:
            {
                var now = DateTime.UtcNow;
                entry.Property(nameof(IEntityModified.Modified)).CurrentValue = now;
                break;
            }
            case EntityState.Added when entity is IEntityAdded or IEntityModified:
            {
                var now = DateTime.UtcNow;

                if (entity is IEntityAdded entityAddedTimestamp)
                {
                    entityAddedTimestamp.Added = now;
                }

                if (entity is IEntityModified entityModifiedTimestamp)
                {
                    entityModifiedTimestamp.Modified = now;
                }

                break;
            }
        }
    }
}