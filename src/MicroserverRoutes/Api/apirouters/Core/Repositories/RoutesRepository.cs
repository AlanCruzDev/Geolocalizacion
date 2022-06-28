


using apirouters.Core.IRepositories;
using apirouters.Data;
using apirouters.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace apirouters.Core.Repositories;
public class RoutesRepository: GenericRepository<Routes>,IRoutesRepository{

  public RoutesRepository(ApplicationDbContext context, ILogger logger, IDataProtector dataProtector, IMapper mapper):base(context,logger,dataProtector,mapper){}
  





}