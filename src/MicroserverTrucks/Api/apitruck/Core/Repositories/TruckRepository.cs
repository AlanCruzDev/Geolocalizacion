using apitruck.Core.IRepositories;
using apitruck.Core.Repositories;
using apitruck.Data;
using apitruck.DTO;
using apitruck.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

public class TruckRepository : GenericRepository<Transport>, ITruckRespository
{

  public TruckRepository(ApplicationDbContext dbContext, ILogger logger, IDataProtector dataProtector, IMapper mapper) : base(dbContext, logger, dataProtector, mapper)
  {}
  public override async Task<bool> Add(Transport entity)
  {
    try
    {

      var existtruck = await _dbSet.Where(x => x.Serie.Equals(entity.Serie) && x.Placa.Equals(entity.Placa)).FirstOrDefaultAsync();
      if(existtruck == null){  
        await _dbSet.AddAsync(entity);
        return true;  
      }
      return false;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Rrpo} Upsert method error", typeof(TruckRepository));
      return false;

    }
  }

   public override async Task<bool> PutTruck(int idruta, PutTruckPackage putTruckPackage){

     try{
       var resulttruck = await _dbSet.Where(x => x.Id == putTruckPackage.Id).AsNoTracking().FirstOrDefaultAsync();
       if(resulttruck == null) return false;

       // verificacion de la cantidad
       if(VerifyStock(resulttruck,putTruckPackage)){
         bool result = ChangeStatusUpdate(idruta,putTruckPackage);
         return result;
       }
       var truckput = _mapper.Map<Transport>(putTruckPackage);
       truckput.RoutesId = idruta;
       truckput.Stock= putTruckPackage.Stock + truckput.Stock;
       truckput.Status = true;
       _context.Trucks.Attach(truckput);
       _context.Entry(truckput).Property(x=> x.RoutesId).IsModified = true;
       _context.Entry(truckput).Property(x=> x.Status).IsModified = true;
       _context.Entry(truckput).Property(x=> x.Stock).IsModified=true;
       return true;
     }catch(Exception ex){
       _logger.LogError(ex,"{Rrpo} Update method error", typeof(TruckRepository));
       return false;
     }
  }
  public bool ChangeStatusUpdate(int idruta, PutTruckPackage putTruckPackage)
  {
    try{
      var truckput = _mapper.Map<Transport>(putTruckPackage);
      truckput.Status = false;
      _context.Trucks.Attach(truckput);
      _context.Entry(truckput).Property(x=> x.Status).IsModified =true;
      return true;
       
    }catch(Exception ex){
      _logger.LogError(ex,"{Rrpo} Update method error", typeof(TruckRepository));
       return false;
    }
  }
  
  public bool VerifyStock(Transport data, PutTruckPackage putTruckPackage){
    int count = data!.Stock + putTruckPackage.Stock;
    if(count > 10){
      return true;
    }
    return false;
  }
  public async override Task<IEnumerable<Transport>> All()
  {
    var result = await _dbSet.Where(x => x.Status== false).ToListAsync();
    return result;
  }
}