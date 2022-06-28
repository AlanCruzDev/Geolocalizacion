namespace apitruck.Models;

public class Encargado{

  public int Id {get; set;}
  public string Nombre {get; set;}
  public string Apellidos {get; set;}
  public string Direccion {get; set;}
  public string Telefono {get; set;}
  public string Cargo  {get; set;}
  public string Usuario {get; set;}
  public string Password {get; set;}

  public List<TransportEncargado> camionEncargados {get;set;}


}