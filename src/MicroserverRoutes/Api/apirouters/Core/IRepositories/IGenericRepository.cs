using apipackages.DTO;
using apirouters.DTO;

namespace apirouters.Core.IRepositories;

public interface IGenericRepository<T> where T: class{

  Task<IEnumerable<T>> All();
   Task<T> GetById(int id);
  Task<bool> Add(T entity);
  Task<bool> Delete(int id);
  Task<bool> Upsert(T entity);
  Task<bool>Put(CoordenatesDTO entity);
  Task<RoutesCoordenatesDTO> GetRoutesCoordenates(int idroute);
  int GetRol(string valor);
}