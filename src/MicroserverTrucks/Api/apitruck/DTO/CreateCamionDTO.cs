
namespace apitruck.DTO;
public class CreateCamionDTO{
  public string Placa {get; set;}
  public string Serie {get; set;}
  public string Colour {get; set;}
  public string Marca {get; set;}
  public string Modelo {get; set;}
  public int Plazas {get; set;}
  public bool Status {get; set;}
  public int Stock {get; set;}
  
  public int TypeTransportId {get; set;}
  public int RoutesId {get; set;}

}