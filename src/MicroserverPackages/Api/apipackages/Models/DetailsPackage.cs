
namespace apipackages.Models;

public class DetailPackage{

  public int Id {get; set;}
  public string TypePackage{get; set;}
  public string Description {get; set;}
  public double PrecioPackage {get; set;}
  public string CodePackage {get; set;}


  // relacion de 1 a muchos
  public int PackageId {get; set;}
  public Package Package {get; set;}

  // relacion de 1 a muchos con empleado
  public int EmployesId {get; set;}
  public Employes Employes {get; set;}


}