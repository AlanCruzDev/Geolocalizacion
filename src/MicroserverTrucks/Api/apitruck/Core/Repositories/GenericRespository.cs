using apitruck.Core.IRepositories;
using apitruck.Data;
using apitruck.DTO;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace apitruck.Core.Repositories;

public class GenericRepository<T>:IGenericRepository<T> where T : class{

  protected readonly ApplicationDbContext _context;
  protected DbSet<T> _dbSet;
  protected readonly ILogger _logger;
  protected readonly IDataProtector _dataProtector;
  protected readonly IMapper _mapper;


  public GenericRepository(ApplicationDbContext context,ILogger logger, IDataProtector dataProtector, IMapper mapper){
    this._context = context;
    this._logger = logger;
    this._dataProtector = dataProtector;
     _dbSet = context.Set<T>();
    this._mapper = mapper;

  }

  public async Task<T> GetById(int id)
  {
    return await _dbSet.FindAsync(id);
  }

  public virtual Task<bool> Add(T entity)
  {
     throw new NotImplementedException();
  }

  public Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> Upsert(T entity)
  {
    throw new NotImplementedException();
  }

  public virtual Task<T> Access(string user, string contrasenia)
  {
    throw new NotImplementedException();
  }

  public virtual Task<EncargadoCamionDTO> GetRoutesDestity(int idUser)
  {
    throw new NotImplementedException();
  }

  public virtual Task<IEnumerable<T>> All()
  {
    throw new NotImplementedException();
  }
  public virtual Task<List<TransportTypeDTO>> GetTypeTransport(int id)
  {
    throw new NotImplementedException();
  }


  public virtual Task<bool> PutTruck(int idruta, PutTruckPackage putTruckPackage)
  {
    throw new NotImplementedException();
  }

}