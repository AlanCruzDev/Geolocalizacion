using apicuestomers.Core.IRepositories;
using apicuestomers.Data;
using apicuestomers.DTO;
using apicuestomers.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace apicuestomers.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{

  private string [] _letrar ={"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","w","x","y","z"};
  private Random _randonw;


  public UserRepository(ApplicationDbContext context, ILogger logger, IDataProtector dataProtector, IMapper mapper) : base(context, logger, dataProtector, mapper)
  { }

  // Aqui vamos a guardar los usuarios

  public override async Task<bool> Add(User entity)
  {
    try
    {
      var existuser = await dbSet.AnyAsync(x => x.Email.Equals(entity.Email));
      if (existuser)
      {
        return false;
      }
      await dbSet.AddAsync(entity);
      return true;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Rrpo} add method error", typeof(UserRepository));
      return false;
    }
  }
  public override async Task<bool> PutUsuario(UserDTO userDTO)
  {
    try{
      var userput = _mapper.Map<User>(userDTO);
      var existeuser = await _context.Users.Where(x => x.Id == userDTO.Id).AnyAsync();
      if(!existeuser){
        return false;
      }
      _context.Users.Attach(userput);

      _context.Entry(userput).Property(x => x.Email).IsModified = true;
      _context.Entry(userput).Property(x => x.Phone).IsModified  = true;
      return true;
    }catch(Exception ex){
      _logger.LogError(ex,"{Repo} Put Actualizar");
      return false;
    }
  }


  public override async Task<string> RecoveryPassword(string correo)
  {
    try{

      var existeusuario = await _context.Users.Where(x=> x.Email.Equals(correo)).FirstOrDefaultAsync();
      if(existeusuario == null){
        return "False";
      }
      string code = GenerateCode();
      
      var user = new User(){
        Id=existeusuario.Id,
        CodigoVerificacion = code
      };

      _context.Users.Attach(user);
      _context.Entry(user).Property(x => x.CodigoVerificacion).IsModified = true;
      return code;


    }catch(Exception ex){
      _logger.LogError(ex,"{Repo} Put Actualizar");
      return "Error";
    }

  }
  private string GenerateCode(){
    string valor ="";
    this._randonw = new Random();
    for(int i=0; i<5;i++){
      int valornuevo = this._randonw.Next(1,100);
      int arreglo = this._randonw.Next(1,this._letrar.Length);
      valor+=""+valornuevo+""+arreglo;
    }
    return valor;

  }


}