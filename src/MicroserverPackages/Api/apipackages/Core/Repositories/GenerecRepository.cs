using apipackages.Core.IRepositories;
using apipackages.Data;
using apipackages.DTO;
using apipackages.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
namespace apipackages.Core.Repositories;

public class GenericRepository<T> : IGenericRepository<T>  where T : class{

  protected readonly ApplicationDbContext _context;
  protected readonly   DbSet<T> dbSet;
  protected readonly ILogger _logger;
  protected readonly IDataProtector _dataProtector;

  protected readonly IMapper _mapper;

  public GenericRepository(ApplicationDbContext context, ILogger logger, IDataProtector dataProtector,IMapper mapper)
  {
    this._context = context;
    this._logger = logger;
    this._dataProtector = dataProtector;
    dbSet = context.Set<T>();
    this._mapper = mapper;
  }



  public virtual async Task<T> GetById(int id)
  {
    return await dbSet.FindAsync(id);
  }

  public virtual async Task<bool> Add(T entity)
  {
    await dbSet.AddAsync(entity);
    return true;
  }

  public virtual Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public virtual Task<bool> Upsert(T entity)
  {
    throw new NotImplementedException();
  }

  public  virtual Task<IEnumerable<T>> All()
  {
    throw new NotImplementedException();
  }

  public virtual Task<string> GetEmailUser(int idroute)
  {
    throw new NotImplementedException();
  }

  public virtual Task<RespuestaAutenticacionDTO> Login(string user, string passworg)
  {
    throw new NotImplementedException();
  }

  public virtual Task<string> RecoveryPassword(putEmployeDTO putEmploye)
  {
    throw new NotImplementedException();
  }

  public virtual Task<string> NewPassword(putEmployeDTO putEmploye)
  {
    throw new NotImplementedException();
  }
}