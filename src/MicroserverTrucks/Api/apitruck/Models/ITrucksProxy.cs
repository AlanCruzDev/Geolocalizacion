using apipackages.DTO;
using apitruck.DTO;

namespace apitruck.Models;
public interface ITrucksProxy{
  Task<RoutesCoordenatesDTO> NameRoutes(int id);  
  Task<UserDTO>GetitBackEmail(int idroute);
}