using apipackages.DTO;
using apirouters.Core.IRepositories;
using apirouters.Data;
using apirouters.DTO;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace apirouters.Core.Repositories;


public class GenericRepository<T> : IGenericRepository<T> where T : class
{


  protected readonly ApplicationDbContext _context;
  protected DbSet<T> _dbSet;
  protected readonly ILogger _logger;
  protected readonly IDataProtector _dataProtector;
  protected readonly IMapper _mapper;

  public GenericRepository(ApplicationDbContext context, ILogger logger, IDataProtector dataProtector, IMapper mapper)
  {
    this._context = context;
    this._logger = logger;
    this._dataProtector = dataProtector;
    _dbSet = context.Set<T>();
    this._mapper = mapper;
  }


  public virtual async Task<bool> Add(T entity)
  {
    await _dbSet.AddAsync(entity);
    return true;
  }

  public virtual async Task<IEnumerable<T>> All()
  {
    return await _dbSet.ToListAsync();
  }

  public virtual Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public virtual async Task<T> GetById(int id)
  {
    return await _dbSet.FindAsync(id);
  }

  public virtual Task<bool> Upsert(T entity)
  {
    throw new NotImplementedException();
  }

  public virtual Task<RoutesCoordenatesDTO> GetRoutesCoordenates(int idroute)
  {
    throw new NotImplementedException();
  }

  public virtual Task<bool> Put(CoordenatesDTO entity)
  {
    throw new NotImplementedException();
  }

  public virtual int GetRol(string valor)
  {
    throw new NotImplementedException();
  }
}


