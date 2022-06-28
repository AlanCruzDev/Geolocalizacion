namespace apirouters.Models;

public class Coordinates{
  public int Id {get; set;}
  public double LatOrigen {get; set;}
  public double LogOrigen {get; set;}
  public double LatDestination {get; set;}
  public double LogDestination {get; set;} 

  public List<Routes> Routes {get; set;}


}