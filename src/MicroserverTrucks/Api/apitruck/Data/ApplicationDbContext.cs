using Microsoft.EntityFrameworkCore;
using apitruck.Models;


namespace apitruck.Data;

public class ApplicationDbContext:DbContext{

  public virtual DbSet<Encargado> Encargados {get; set;}
  public virtual DbSet<Transport> Trucks {get; set;}

  public virtual DbSet<TypeTransport> Types {get; set;}

  public virtual DbSet<TransportEncargado> CamionEncargados {get; set;}



  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions){

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<TransportEncargado>().HasKey(al => new {al.EncargadoId,al.TruckId});
  }

}