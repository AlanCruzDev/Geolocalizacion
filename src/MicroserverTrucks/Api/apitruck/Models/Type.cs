namespace apitruck.Models;

public class TypeTransport{
  public int Id {get; set;}
  public string nametype {get; set;}

  // propiedades de navegacion
  public List<Transport> transports {get; set;}
}