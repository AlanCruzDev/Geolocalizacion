using apipackages.Core.Repositories;
using apirouters.Core.IConfiguration;
using apirouters.Core.IRepositories;
using apirouters.Core.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace apirouters.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
  private readonly ApplicationDbContext _context;
  private readonly ILogger _logger;
  public IRoutesRepository Routes  {get; private set;}

  public ICoordenateRepository Coordenate {get; private set;}

  private readonly IDataProtector dataProtector;
  private readonly IMapper _mapper;

  public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory, IDataProtectionProvider dataProtectionProvider, IMapper mapper)
  {
    _context = context;
    _logger = loggerFactory.CreateLogger("logs");
    dataProtector = dataProtectionProvider.CreateProtector("Valor_unico");
    _mapper = mapper;
    Routes = new RoutesRepository(_context,_logger,dataProtector,_mapper);
    Coordenate = new CoordenateRepository(_context,_logger,dataProtector,_mapper);
  }

   public async Task CompleteAsync(){
    await _context.SaveChangesAsync();
  }

  public void Dispose(){
    _context.Dispose();
  }
}