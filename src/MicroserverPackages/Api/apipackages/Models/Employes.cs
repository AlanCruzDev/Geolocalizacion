using System.ComponentModel;
namespace apipackages.Models;

public enum Roles{
  Administrador = 1,
  Empleado=2,
  Director=3,
  Sistemas=4
}

public class Employes{
  public int Id {get; set;}
  public string Nombre {get; set;}
  public string Apellidos {get; set;}
  public string NumEmpleado {get; set;}
  public string Usuario {get; set;}
  public string password {get; set;}
  public string CodeVerify {get; set;}
  public bool Activo {get; set;}
  
  public int Roles {get; set;}
  // propiedad de navegacion
  public List<DetailPackage> detailPackages {get; set;}

}