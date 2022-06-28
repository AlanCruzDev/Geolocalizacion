using Microsoft.EntityFrameworkCore;
namespace apipackages.Data;
using Models;

public class ApplicationDbContext:DbContext{

  public virtual DbSet<Package> Packages {get; set;}
  public virtual DbSet<DetailPackage> DetailPackages {get; set;}
  public virtual DbSet<Employes> Employes {get; set;}

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions){

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
     modelBuilder.Entity<Employes>()
                .ToTable("Employes");
                
      modelBuilder.Entity<Employes>()
        .Property(e => e.Roles)
        .HasConversion<string>();

    base.OnModelCreating(modelBuilder);
  }

}