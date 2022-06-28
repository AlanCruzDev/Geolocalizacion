namespace apitruck.Models;
public class Transport{

  public int Id {get; set;}
  public string Placa {get; set;}
  public string Serie {get; set;}
  public string Colour {get; set;}
  public string Marca {get; set;}
  public string Modelo {get; set;}
  public int Plazas {get; set;}
  public bool Status {get; set;}
  public int RoutesId {get; set;}

  public int Stock {get; set;}

  // Relacion de 1 a muchos
  public int TypeTransportId {get; set;}
  public TypeTransport typeTransport {get; set;}

  // Propiedades de Navegacion
  public List<TransportEncargado> camionEncargados {get;set;}

}