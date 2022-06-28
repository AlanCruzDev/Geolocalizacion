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

}