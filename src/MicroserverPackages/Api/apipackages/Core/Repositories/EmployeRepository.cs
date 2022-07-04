using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apipackages.Core.IRepositories;
using apipackages.Data;
using apipackages.DTO;
using apipackages.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace apipackages.Core.Repositories;
public class EmployeRepository : GenericRepository<Employes>, IEmploye
{
  
  private string [] _letrar ={"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","w","x","y","z"};
  private Random _randonw;


  public EmployeRepository(ApplicationDbContext context, ILogger logger, IDataProtector dataProtector, IMapper mapper) : base(context, logger, dataProtector, mapper)
  {
  }

  public override async Task<bool> Add(Employes entity)
  {
    try
    {

      var user = await dbSet.Where(x => x.Usuario.Equals(entity.Usuario)).FirstOrDefaultAsync();
      if (user == null)
      {
        await dbSet.AddAsync(entity);
        return true;
      }
      return false;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Rrpo} add method error", typeof(PackageRepository));
      return false;
    }
  }
  public override async Task<RespuestaAutenticacionDTO> Login(string user, string passworg)
  {
    try
    {
      var userexiste = await dbSet.Where(x => x.Usuario.Equals(user)).FirstOrDefaultAsync();
     

      if (userexiste == null)
      {
        return new RespuestaAutenticacionDTO()
        {
          Token = "",
          Expiracion = new DateTime(),
          Rol = 0
        };
      }
      if(!userexiste.password.Equals(passworg)){
        return new RespuestaAutenticacionDTO()
        {
          Token = "",
          Expiracion = new DateTime(),
        };
      }
      if(!userexiste.Activo){
        return new RespuestaAutenticacionDTO()
        {
          Token = "",
          Expiracion = new DateTime(),
        };
      }

      return ConstruirToken(userexiste.Id, userexiste.Roles);

    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Rrpo} Iniciar Sesion method error", typeof(EmployeRepository));
      return new RespuestaAutenticacionDTO()
      {
        Token = "",
        Expiracion = new DateTime()
      };
    }
  }

  private RespuestaAutenticacionDTO ConstruirToken(int id, int rol)
  {
    Console.WriteLine(id);
    var textoCifradoID = id.ToString();

    var claims = new List<Claim>()
            {
                new Claim("id",textoCifradoID)
            };
    var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KLSDJFKLDSJFDSKLJFDSLKJFDSLFJDSLKJFDKLJFDSKJF434343243243J2KL43J2LKDSLAKDSA4431"));
    var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

    var expiracion = DateTime.UtcNow.AddYears(1);
    var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);
    return new RespuestaAutenticacionDTO()
    {
      Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
      Expiracion = expiracion,
      Rol = rol
    };

  }
  
  public override async Task<string> RecoveryPassword(putEmployeDTO putEmploye)
  {
    try{      
      var res = await _context.Employes.FirstOrDefaultAsync(x => x.Usuario.Equals(putEmploye.email));
      if (res == null){
        return "False";
      }
       string code = GenerateCode();
       res.CodeVerify= code;
       return code;
    }catch(Exception ex){
      _logger.LogError(ex,"{Repo} Put Actualizar");
      return "Error";
    }
  }
  public override async Task<string> NewPassword(putEmployeDTO putEmploye)
  {
    try{
      var res = await _context.Employes.FirstOrDefaultAsync(x => x.CodeVerify.Equals(putEmploye.CodeVerify));
      if (res == null){
        return "False";
      }
      res.CodeVerify = "";
      res.password = putEmploye.password;
      return "True";
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
      valor+=""+valornuevo+""+this._letrar[arreglo];
    }
    return valor;
  }

}