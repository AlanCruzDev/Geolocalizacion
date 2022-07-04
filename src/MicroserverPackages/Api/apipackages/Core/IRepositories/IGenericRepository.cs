using apipackages.DTO;
using apipackages.Models;

namespace apipackages.Core.IRepositories;


public interface IGenericRepository<T> where T : class{

  Task<IEnumerable<T>> All();
  Task<T> GetById(int id);
  Task<bool> Add(T entity);
  Task<bool> Delete(int id);
  Task<bool> Upsert(T entity);
  Task<string> GetEmailUser(int idroute);
  Task<RespuestaAutenticacionDTO>Login(string user, string passworg);
  Task<string> RecoveryPassword(putEmployeDTO putEmploye);
  Task<string> NewPassword(putEmployeDTO putEmploye);
  

}