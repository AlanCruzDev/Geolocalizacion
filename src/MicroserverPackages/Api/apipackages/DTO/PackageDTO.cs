
namespace apipackages.DTO;

// propiedades de la tabla paquetes
public class CreateNewPackageDTO{
  //public DateTime FechaEnvio {get; set;}
  //public DateTime FechaEntrega {get; set;}
  public bool EstadoEntrega  {get; set;}
  public double SubtotalPaquete {get; set;}
  public double IvaPaquete {get; set;}
  public double TotalPaquete {get; set;}
  public string OrigenPaquete {get; set;}
  public string DestinoPaquete{get; set;}

  // Propiedades de Routes
   public int IdRuta {get; set;}
   public int IdCoordinates {get; set;}

   public int IdUser {get; set;}

     // empleado 
   public int IdEmploye {get; set;}

  // propiedades de la tabla Detail Package

   public string TypePackage{get; set;}
  public string Description {get; set;}
  public double PrecioPackage {get; set;}
  public string CodePackage {get; set;}
  public int PackageId {get; set;}

  // propiedades coordenadas

  
  public double LatOrigen {get; set;}
  public double LogOrigen {get; set;}
  public double LatDestination {get; set;}
  public double LogDestination {get; set;} 

}
