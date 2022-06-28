namespace apitruck.DTO;
public class TransportDTO{
  
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
}