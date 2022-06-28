using apitruck.Core.IRepositories;
namespace apitruck.Core.IConfiguration;

public interface IUnitOfWork{

  IEncargadoRepository encargado {get;}
  ITruckRespository truck {get;}

  ITypeTransportRepository typeTransport {get;}

  Task CompleteAsync();


}