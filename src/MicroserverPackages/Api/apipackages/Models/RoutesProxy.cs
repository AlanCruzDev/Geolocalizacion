using apipackages.DTO;
namespace apipackages.Models;

public interface IRoutesProxy{

  Task InsertDetailPackage(CreateNewPackageDTO createNewPackageDTO);
  Task<UserDTO> GetEmail(int idUser);


}