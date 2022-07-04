namespace apicuestomers.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using apicuestomers.Core.IRepositories;
using apicuestomers.Data;
using apicuestomers.DTO;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
  protected ApplicationDbContext _context;
  protected DbSet<T> dbSet;
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
  public virtual async Task<IEnumerable<T>> All(){
    return await dbSet.ToListAsync();
  }
  public virtual Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }
  public virtual async Task<T> GetById(int id)
  {
    return await dbSet.FindAsync(id);
  }
  public virtual Task<bool> Add(T entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool> Upsert(T entity)
  {
    throw new NotImplementedException();
  }

  public virtual Task<bool> PutUsuario(UserDTO userDTO)
  {
    throw new NotImplementedException();
  }

  public virtual Task<string> RecoveryPassword(string correo)
  {
    throw new NotImplementedException();
  }
}