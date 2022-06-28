namespace apitruck.Models;


public class TransportEncargado{

  public int EncargadoId{get; set;}
  public int TruckId {get; set;}

  public Encargado encargado {get; set;}
  public Transport truck {get; set;}

}