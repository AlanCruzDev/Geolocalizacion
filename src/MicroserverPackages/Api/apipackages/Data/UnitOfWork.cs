using apipackages.Core.IConfiguration;
using apipackages.Data;
using apipackages.Core.IRepositories;
using Microsoft.AspNetCore.DataProtection;
using AutoMapper;
using apipackages.Core.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable{

  private readonly ApplicationDbContext _context;
  private readonly ILogger _logger;

  public IDetailPackage DetailPackage  {get; private set;}

  public IPackage Packa  {get; private set;}

  public IEmploye Employe  {get; private set;}

  private readonly IDataProtector dataProtector;
  private readonly IMapper _mapper;

  public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory, IDataProtectionProvider dataProtectionProvider, IMapper mapper)
  {
    _context = context;
    _logger = loggerFactory.CreateLogger("logs");
    dataProtector = dataProtectionProvider.CreateProtector("Valor_unico");
    this._mapper = mapper;
    Packa = new PackageRepository(_context,_logger,dataProtector,_mapper);
    DetailPackage = new DetailPackageRepository(_context,_logger,dataProtector,_mapper);
    Employe = new EmployeRepository(_context,_logger,dataProtector,_mapper);
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

