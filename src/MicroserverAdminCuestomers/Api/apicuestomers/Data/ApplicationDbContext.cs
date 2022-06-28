using Microsoft.EntityFrameworkCore;
namespace apicuestomers.Data;
using Models;

public class ApplicationDbContext:DbContext{

  public virtual DbSet<User> Users {get; set;}

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions){

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }

}


