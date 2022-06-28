using apitruck.Core.IRepositories;
using apitruck.Core.Repositories;
using apitruck.Data;
using apitruck.DTO;
using apitruck.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

public class TypeTransportRepository : GenericRepository<TypeTransport>, ITypeTransportRepository
{

  public TypeTransportRepository(ApplicationDbContext dbContext, ILogger logger, IDataProtector dataProtector, IMapper mapper) : base(dbContext, logger, dataProtector, mapper)
  { }

  public override async Task<bool> Add(TypeTransport entity)
  {
    try
    {

      var existencia = await _dbSet.Where(x => x.nametype.Equals(entity.nametype)).FirstOrDefaultAsync();
      if (existencia == null)
      {
        await _dbSet.AddAsync(entity);
        return true;
      }
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Rrpo} Upsert method error", typeof(TypeTransportRepository));
    }
    return false;
  }
  public override async Task<List<TransportTypeDTO>> GetTypeTransport(int id)
  {

    var gettypes = await _dbSet
      .Include(typedb => typedb.transports).Where(x => x.transports.Any(y => y.Status == false) && x.Id == id).ToListAsync();
    return _mapper.Map<List<TransportTypeDTO>>(gettypes);
  }
  public override async Task<IEnumerable<TypeTransport>> All(){
    var respuesta = await _dbSet.ToListAsync();
    return respuesta;
  }
}