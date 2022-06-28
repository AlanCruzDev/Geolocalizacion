using apirouters.Core.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using apirouters.Models;
using apirouters.Core.IRepositories;
using apirouters.Data;
using Microsoft.EntityFrameworkCore;
using apipackages.DTO;
using apirouters.DTO;

namespace apipackages.Core.Repositories;
public class CoordenateRepository:GenericRepository<Coordinates>,ICoordenateRepository{

  public CoordenateRepository(ApplicationDbContext context, ILogger logger,IDataProtector dataProtector,IMapper mapper): base(context,logger,dataProtector,mapper){
   
  }
  public override async Task<RoutesCoordenatesDTO> GetRoutesCoordenates(int idroute){
      var getroutes = await _dbSet
          .Include(routesdb => routesdb.Routes).Where(c => c.Routes.Any(x => x.Id == idroute)).FirstOrDefaultAsync();
     return _mapper.Map<RoutesCoordenatesDTO>(getroutes);
  }
  public override async Task<bool> Put(CoordenatesDTO entity)
  {
    try{
        var result = await _dbSet.Where(x=> x.Id == entity.Id).AsNoTracking().FirstOrDefaultAsync();
        if(result == null) return false;

        var _coordenates = _mapper.Map<Coordinates>(entity);
        _coordenates.LatOrigen = entity.LatOrigen;
        _coordenates.LogOrigen = entity.LogOrigen;

        _context.Coordinates.Attach(_coordenates);
        _context.Entry(_coordenates).Property(x => x.LatOrigen).IsModified = true;
        _context.Entry(_coordenates).Property(x => x.LogOrigen).IsModified = true;
        return true;
    }catch(Exception ex){
       _logger.LogError(ex,"{Rrpo} Update method error", typeof(CoordenateRepository));
       return false;
    }
  }

  public override int GetRol(string valor)
  {
     try{
        var decifrar = _dataProtector.Unprotect(valor);
         Console.WriteLine(decifrar);

     }catch(Exception e){
         Console.WriteLine(e);
     }
     return 0;
  }
}