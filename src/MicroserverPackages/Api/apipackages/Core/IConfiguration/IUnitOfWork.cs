using apipackages.Core.IRepositories;
namespace apipackages.Core.IConfiguration;

public interface IUnitOfWork{
  IPackage Packa {get;}
  IDetailPackage DetailPackage {get;}
  IEmploye Employe {get;}



  Task CompleteAsync();
}

