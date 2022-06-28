using apitruck.Core.IConfiguration;
using apitruck.Core.IRepositories;
using apitruck.Core.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace apitruck.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{

  private readonly ApplicationDbContext _dbContext;
  private readonly ILogger _logger;
  private readonly IDataProtector _dataProtector;
  private readonly IMapper _mapper;
  public IEncargadoRepository encargado {get; private set;}

  public ITruckRespository truck {get; private set;}

  public ITypeTransportRepository typeTransport {get; private set;}

  public UnitOfWork(ApplicationDbContext  context, ILoggerFactory loggerFactory,IDataProtectionProvider dataProtectionProvider,IMapper mapper)
  {
    _dbContext =context;
    _logger = loggerFactory.CreateLogger("logs");
    _dataProtector = dataProtectionProvider.CreateProtector("Valor_unico");
    _mapper = mapper;
    encargado = new EncargadoRepository(_dbContext,_logger,_dataProtector,_mapper);
    truck = new TruckRepository(_dbContext,_logger,_dataProtector,_mapper);
    typeTransport = new TypeTransportRepository(_dbContext,_logger,_dataProtector,_mapper);
  }

  public async Task CompleteAsync()
  {
    await _dbContext.SaveChangesAsync();
  }

  public void Dispose()
  {
    _dbContext.Dispose();
  }
}