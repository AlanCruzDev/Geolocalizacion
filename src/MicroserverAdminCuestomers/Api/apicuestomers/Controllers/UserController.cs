using apicuestomers.Core.IConfiguration;
using apicuestomers.DTO;
using apicuestomers.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace apicuestomers.Controllers;

[ApiController]
[Route("v1/user")]
public class UserController : ControllerBase
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public UserController(IUnitOfWork unitOfWork, IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
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
      await _unitOfWork.User.Add(newuser);
      await _unitOfWork.CompleteAsync();
      return CreatedAtAction("GetItem", new { id = newuser.Id }, createUserDTO);
    }
    return new JsonResult("Fall") { StatusCode = 500 };
  }
  [HttpPut ("{iduser}")]
  public async Task<ActionResult> PutUser(UserDTO userDTO, int iduser){
    if(ModelState.IsValid){
      var resp = await _unitOfWork.User.PutUsuario(userDTO);
      await _unitOfWork.CompleteAsync();
      if(resp){
        return Ok(new {
          ok = true,
          msg="Se Actualizo Correctamente"
        });
      }
      return NoContent();
    }
    return new JsonResult("Fail") {StatusCode= 500};
  }
}