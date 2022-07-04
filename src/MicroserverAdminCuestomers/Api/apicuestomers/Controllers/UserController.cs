using apicuestomers.Core.IConfiguration;
using apicuestomers.DTO;
using apicuestomers.Models;
using apicuestomers.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace apicuestomers.Controllers;

[ApiController]
[Route("v1/user")]
public class UserController : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  private readonly IEmailSender _emailSender;

  public UserController(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
    _emailSender = emailSender;
  }
  [HttpGet("watch/{id}")]
  public async Task<IActionResult> GetItem(int id)
  {
    var user = await _unitOfWork.User.GetById(id);
    Console.WriteLine(user);
    return Ok(user);
  }

  [HttpGet("everyone")]
  public async Task<ActionResult<List<UserDTO>>> GetUsers()
  {
    var user = await _unitOfWork.User.All();
    return _mapper.Map<List<UserDTO>>(user);
  }
  [HttpPost]
  public async Task<ActionResult> PostUser(CreateUserDTO createUserDTO)
  {
    if (ModelState.IsValid)
    {
      var newuser = _mapper.Map<User>(createUserDTO);
      newuser.CodigoVerificacion = "";
      await _unitOfWork.User.Add(newuser);
      await _unitOfWork.CompleteAsync();
      return CreatedAtAction("GetItem", new { id = newuser.Id }, createUserDTO);
    }
    return new JsonResult("Fall") { StatusCode = 500 };
  }

  [HttpPut("generate/code/{email}")]
  public async Task<ActionResult> PostCodigoVerificacion(string email)
  {
    if (!email.Equals(""))
    {

      var result = await _unitOfWork.User.RecoveryPassword(email);
      if (result.Equals("False") || result.Equals("Error")){
        return NoContent();
      }
      else{
        return Ok(new {
          ok = true,
          msg =result
        });
      }

      await this._emailSender.SendEmailAsync(email, "Recuperacion de Password", "");
    }
    return new JsonResult("Fail")
    {
      StatusCode = 404
    };
  }

  [HttpPut("{iduser}")]
  public async Task<ActionResult> PutUser(UserDTO userDTO, int iduser)
  {
    if (ModelState.IsValid)
    {
      var resp = await _unitOfWork.User.PutUsuario(userDTO);
      await _unitOfWork.CompleteAsync();
      if (resp)
      {
        return Ok(new
        {
          ok = true,
          msg = "Se Actualizo Correctamente"
        });
      }
      return NoContent();
    }
    return new JsonResult("Fail") { StatusCode = 500 };
  }
}