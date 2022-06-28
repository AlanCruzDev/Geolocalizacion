using apitruck.Models;

namespace apitruck.DTO;
public class TransportTypeDTO:TypeDTO{

  public List<TransportDTO> transports {get; set;}
}