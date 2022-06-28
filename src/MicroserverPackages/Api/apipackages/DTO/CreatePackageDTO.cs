namespace apipackages.DTO;


public class CreatePackageDTO{
  public DateTime FechaEnvio {get; set;}
  public DateTime FechaEntrega {get; set;}
  public bool EstadoEntrega  {get; set;}
  public double SubtotalPaquete {get; set;}
  public double IvaPaquete {get; set;}
  public double TotalPaquete {get; set;}
  public string OrigenPaquete {get; set;}
  public string DestinoPaquete{get; set;}
 
  // Relacion de uno a muchos con la tabla ruta
  public int IdRuta {get; set;}
  public int IdUser {get; set;}

}