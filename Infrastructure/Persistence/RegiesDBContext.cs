using Microsoft.EntityFrameworkCore;
using Regies.Domain.Model;

namespace Regies.Infrastructure.Persistence;

public class RegiesDBContext(DbContextOptions<RegiesDBContext> dbContextOptions) : DbContext(dbContextOptions)
{
    internal DbSet<Regie> Regies { get; set; }

    internal DbSet<BienImmobilier> BienImmobiliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Regie>()
            .OwnsOne( r =>  r.Adresse );

        modelBuilder.Entity<BienImmobilier>()
            .OwnsOne(b => b.Adresse);

        modelBuilder.Entity<Regie>()
            .HasMany(r => r.lesBiensDeLaRegie)
            .WithOne()
            .HasForeignKey(bi => bi.RegieId );

        modelBuilder.Entity<BienImmobilier>()
            .Property(bi => bi.prixLocatif)
            .HasColumnType("numeric")
            .HasPrecision(10,2);

        modelBuilder.Entity<BienImmobilier>()
            .Property(bi => bi.prixVente)
            .HasColumnType("numeric")
            .HasPrecision(10,2);
    }

}
