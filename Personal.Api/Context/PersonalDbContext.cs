using Microsoft.EntityFrameworkCore;
using Personal.Shared.Models;

namespace Personal.Api.Context;

public class PersonalDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Binnacle> Binnacles { get; set; }

     public override int SaveChanges()
    {
        OnBeforeChanges();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeChanges();
        return await base.SaveChangesAsync(cancellationToken);
    }


    private void OnBeforeChanges()
    {
        DateTime now = DateTime.Now;
        List<Binnacle> binnacles = new List<Binnacle>();

        foreach (var entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted))
        {
            if(entry.Entity is Entity)       
            {
                if(entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).CreatedAt = now;
                }

                Binnacle binnacle = new(){
                    Id = Guid.NewGuid(),
                    Entity = (Guid)entry.Property(nameof(Entity.Id)).CurrentValue,
                    Action = Enum.GetName(typeof(EntityState), entry.State),
                    Type = entry.Entity.GetType().Name,
                    TimeOff = now
                };
                binnacles.Add(binnacle);
            }
        }

        this.Binnacles.AddRange(binnacles);
    }

}