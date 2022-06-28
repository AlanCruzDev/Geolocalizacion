using apicuestomers.Core.IRepositories;

namespace apicuestomers.Core.IConfiguration;

public interface IUnitOfWork{

  IUserRepository User {get;}
  Task CompleteAsync();
}