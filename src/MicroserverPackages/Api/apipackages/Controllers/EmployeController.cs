using apipackages.Core.IConfiguration;
using apipackages.DTO;
using apipackages.Models;
using apipackages.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace apipackages.Controllers;

[ApiController]
[Route("v1/employe")]
public class EmployeController : ControllerBase
{

  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  private readonly IEmailSender _emailSender;
  public EmployeController(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
  {
    this._mapper = mapper;
    this._unitOfWork = unitOfWork;
    _emailSender = emailSender;
  }

  [HttpGet("{user}/{password}")]
  public async Task<ActionResult> GetLogin(string user, string password)
  {
    if (!user.Equals("") && !password.Equals(""))
    {

      var res = await _unitOfWork.Employe.Login(user, password);

      if (res.Token.Equals(""))
      {
        return BadRequest(new
        {
          ok = false,
          msg = "Usuario/Contraseña Incorrectas"
        });
      }
      return Ok(new
      {
        ok = true,
        msg = res
      });
    }
    return new JsonResult("Fail")
    {
      StatusCode = 500
    };
  }

  [HttpPost]
  public async Task<ActionResult> PostEmploye(EmployesDTO employesDTO)
  {

    if (ModelState.IsValid)
    {
      var employe = _mapper.Map<Employes>(employesDTO);
      employe.CodeVerify ="";
      if (employesDTO.rol.Equals("Administrador"))
      {
        employe.Roles = (int)Roles.Administrador;
      }
      if (employesDTO.rol.Equals("Empleado"))
      {
        employe.Roles = (int)Roles.Empleado;
      }
      await _unitOfWork.Employe.Add(employe);
      await _unitOfWork.CompleteAsync();
      return NoContent();
    }
    return new JsonResult("Fail") { StatusCode = 500 };
  }
  
  [HttpPut("generate/code")]
  public async Task<ActionResult> PostCodigoVerificacion(putEmployeDTO employedto)
  {
    if (!employedto.email.Equals(""))
    {

      var result = await _unitOfWork.Employe.RecoveryPassword(employedto);
      await _unitOfWork.CompleteAsync();
      if (result.Equals("False") || result.Equals("Error"))
      {
        return NoContent();
      }
      else
      {
        await this._emailSender.SendEmailAsync(employedto.email, "Codigo de recuperacion", result );
        return Ok(new
        {
          ok = true,
          msg = result
        });
      }
    }
    return new JsonResult("Fail")
    {
      StatusCode = 404
    };
  }
  [HttpPut("new/credenciales")]
  public async Task<ActionResult> PutNewCredenciales(putEmployeDTO employedto)
  {
    try{
      if (!employedto.password.Equals("")){

      var result = await _unitOfWork.Employe.NewPassword(employedto);
      await _unitOfWork.CompleteAsync();

      if (result.Equals("False") || result.Equals("Error"))
      {
        return NoContent();
      }
      else
      {
        return Ok(new
        {
          ok = true,
          msg = "Contraseña se cambio Correctamente"
        });
      }
    }

    }catch(Exception ex){
      Console.WriteLine(ex.Message);
    }
    
    return new JsonResult("Fail")
    {
      StatusCode = 404
    };
    
  }
  [HttpGet]
  public async Task<ActionResult> GetEmployes(){
    IEnumerable<Employes> result = await _unitOfWork.Employe.All();
    
    
    return Ok(result);
  }
   [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteEmploye(int id){
    bool result = await _unitOfWork.Employe.Delete(id);
    await _unitOfWork.CompleteAsync();
    if(result){
      return Ok();
    }
    return new JsonResult("Fail"){
      StatusCode=404
    };
  }

}