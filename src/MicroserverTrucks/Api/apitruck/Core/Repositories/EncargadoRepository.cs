using apitruck.Core.IRepositories;
using apitruck.Data;
using apitruck.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using apitruck.DTO;

namespace apitruck.Core.Repositories;

public class EncargadoRepository : GenericRepository<Encargado>,IEncargadoRepository{

  public EncargadoRepository(ApplicationDbContext dbContext, ILogger logger,IDataProtector dataProtector,IMapper mapper):base(dbContext,logger,dataProtector,mapper){
    
  }

  public override async Task<Encargado> Access(string user, string contrasenia){
    try{

      var userone = await _dbSet.Where(x => x.Usuario.Equals(user)).FirstOrDefaultAsync();
      if(userone == null){
        return new Encargado();
      }
      if(!userone.Password.Equals(contrasenia)){
          return new Encargado();
      } 
      return userone;
    }catch(Exception ex){
       _logger.LogError(ex, "{Rrpo} Upsert method error", typeof(TruckRepository));
      return new Encargado();

    }
  }
  public override async Task<EncargadoCamionDTO> GetRoutesDestity(int idUser){
    try{
    var encargadoone= await _dbSet.Include(encarDB => encarDB.camionEncargados)
                                    .ThenInclude(camionencarga => camionencarga.truck).FirstOrDefaultAsync(x => x.Id == idUser);
    return _mapper.Map<EncargadoCamionDTO>(encargadoone);

    }
    catch(Exception  ex){
      _logger.LogError(ex, "{Rrpo} Upsert method error", typeof(TruckRepository));
      return new EncargadoCamionDTO();
    }
  }
  public override async Task<bool> Add(Encargado entity){
     await _dbSet.AddAsync(entity);
     return true;
  }
}