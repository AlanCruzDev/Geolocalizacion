using apirouters.Core.IRepositories;

namespace apirouters.Core.IConfiguration;

public interface IUnitOfWork{
  IRoutesRepository Routes{get;}
  ICoordenateRepository Coordenate {get;}
  Task CompleteAsync();
}