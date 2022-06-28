using apipackages.Core.IConfiguration;
using apipackages.DTO;
using apipackages.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace apipackages.Controllers;

[ApiController]
[Route("v1/employe")]
public class EmployeController:ControllerBase{

  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public EmployeController(IUnitOfWork unitOfWork, IMapper mapper){
    this._mapper=mapper;
    this._unitOfWork= unitOfWork;
  }

  [HttpGet("{user}/{password}")]
  public async Task<ActionResult> GetLogin(string user, string password){
    if(!user.Equals("") && !password.Equals("")){

      var res   = await _unitOfWork.Employe.Login(user,password);
      
      if(res.Token.Equals("")){
        return BadRequest(new {
          ok= false,
          msg = "Usuario/Contraseña Incorrectas"
        });
      }
      return Ok(new {
        ok = true,
        msg = res
      });
    }
    return new JsonResult("Fail"){
      StatusCode = 500
    };
  }

  [HttpPost]
  public async Task<ActionResult> PostEmploye(EmployesDTO employesDTO){

    if(ModelState.IsValid){
      var employe = _mapper.Map<Employes>(employesDTO);
      if(employesDTO.rol.Equals("Administrador")){
        employe.Roles =(int) Roles.Administrador;
      }
      if(employesDTO.rol.Equals("Empleado")){
        employe.Roles =(int) Roles.Empleado;
      }
      await _unitOfWork.Employe.Add(employe);
      await _unitOfWork.CompleteAsync();
      return NoContent();
    }
     return new JsonResult("Fail") { StatusCode = 500 };

  }
}