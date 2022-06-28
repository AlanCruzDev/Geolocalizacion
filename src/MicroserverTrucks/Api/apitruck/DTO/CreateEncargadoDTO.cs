
namespace apitruck.DTO;
public class CreateEncargadoDTO{

  public string Nombre {get; set;}
  public string Apellidos {get; set;}
  public string Direccion {get; set;}
  public string Telefono {get; set;}
  public string Cargo  {get; set;}
  public string Usuario {get; set;}
  public string Password {get; set;}

  // Lista de Camiones
  public List<int> CamionId {get; set;}

}