using apipackages.Core.IRepositories;
using apipackages.Data;
using apipackages.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
namespace apipackages.Core.Repositories;

public class DetailPackageRepository: GenericRepository<DetailPackage>, IDetailPackage{

  public DetailPackageRepository(ApplicationDbContext context, ILogger logger,IDataProtector dataProtector,IMapper mapper): base(context,logger,dataProtector,mapper){}




}