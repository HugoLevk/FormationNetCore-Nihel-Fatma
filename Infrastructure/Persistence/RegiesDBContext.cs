using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Regies.Domain.Model;
using System.Reflection.Emit;

namespace Regies.Infrastructure.Persistence;

public class RegiesDBContext(DbContextOptions<RegiesDBContext> dbContextOptions) : IdentityDbContext<User>(dbContextOptions)
{
    internal DbSet<Regie> Regies { get; set; }

    internal DbSet<BienImmobilier> BienImmobiliers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Regie>()
            .OwnsOne( r =>  r.Adresse );

        builder.Entity<BienImmobilier>()
            .OwnsOne(b => b.Adresse);

        builder.Entity<Regie>()
            .HasMany(r => r.lesBiensDeLaRegie)
            .WithOne()
            .HasForeignKey(bi => bi.RegieId );

        builder.Entity<BienImmobilier>()
            .Property(bi => bi.prixLocatif)
            .HasColumnType("numeric")
            .HasPrecision(10,2);

        builder.Entity<BienImmobilier>()
            .Property(bi => bi.prixVente)
            .HasColumnType("numeric")
            .HasPrecision(10,2);

        builder.Entity<User>()
                .HasMany(p => p.OwnedRegies)
                .WithOne(r => r.Owner)
                .HasForeignKey(r => r.OwnerId);
    }

}
