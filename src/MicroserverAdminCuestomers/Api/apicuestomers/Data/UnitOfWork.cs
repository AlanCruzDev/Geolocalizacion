using apicuestomers.Core.IConfiguration;
using apicuestomers.Core.IRepositories;
using apicuestomers.Repositories;
using Microsoft.AspNetCore.DataProtection;
using AutoMapper;

namespace apicuestomers.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{

  private readonly ApplicationDbContext _context;
  private readonly ILogger _logger;
  public IUserRepository User { get; private set; }
  private readonly IDataProtector dataProtector;
  private readonly IMapper _mapper;


  public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory, IDataProtectionProvider dataProtectionProvider, IMapper mapper)
  {
    _context = context;
    _logger = loggerFactory.CreateLogger("logs");
    dataProtector = dataProtectionProvider.CreateProtector("Valor_unico");
    this._mapper = mapper;
    User = new UserRepository(_context, _logger, dataProtector,_mapper);
  }

  public async Task CompleteAsync()
  {
    await _context.SaveChangesAsync();
  }

  public void Dispose()
  {
    _context.Dispose();
  }




}