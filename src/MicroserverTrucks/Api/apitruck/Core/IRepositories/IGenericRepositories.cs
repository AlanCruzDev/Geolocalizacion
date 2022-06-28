using apitruck.DTO;

namespace apitruck.Core.IRepositories;


public interface IGenericRepository<T> where T:class{

  Task<IEnumerable<T>> All();
  Task<T> GetById(int id);
  Task<bool> Add(T entity);
  Task<bool> Delete(int id);
  Task<bool> Upsert(T entity);
  Task<T> Access (string user, string contrasenia);
  Task<EncargadoCamionDTO> GetRoutesDestity(int idUser);
  Task<List<TransportTypeDTO>> GetTypeTransport(int id);

  Task<bool>PutTruck(int idruta,PutTruckPackage putTruckPackage);

}