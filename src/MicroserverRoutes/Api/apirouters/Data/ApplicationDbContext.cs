using Microsoft.EntityFrameworkCore;
namespace apirouters.Data;
using Models;

public class ApplicationDbContext:DbContext{

  public virtual DbSet<Routes> Routes {get; set;}
  public virtual DbSet<Coordinates> Coordinates {get; set;}

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions){

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }

}

