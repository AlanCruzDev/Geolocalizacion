namespace apipackages.Models;

public class CreateDetailPackageDTO{

  public string TypePackage{get; set;}
  public string Description {get; set;}
  public double PrecioPackage {get; set;}
  public string CodePackage {get; set;}
  // relacion de 1 a muchos
  public int PackageId {get; set;}
  public Package Package {get; set;}

}