using apitruck.Core.IConfiguration;
using AutoMapper;
using apitruck.DTO;
using Microsoft.AspNetCore.Mvc;
using apitruck.Models;

[ApiController]
[Route("v1/encargado")]

public class EncargadoController:ControllerBase{

  private readonly IUnitOfWork _unitofwork;
  private readonly IMapper _mapper;
  private readonly ITrucksProxy _trucksProxy;

  public EncargadoController(IUnitOfWork unitOfWork, IMapper mapper,ITrucksProxy trucksProxy){
    _unitofwork=unitOfWork;
    _mapper = mapper;
    _trucksProxy = trucksProxy;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult>GetItem(int id){
    var newencargado = await _unitofwork.encargado.GetById(id);
    return Ok(newencargado);
  }
  
  [HttpGet("{user}/{contrasenia}")]
  public async Task<ActionResult> GetAcceso(string user, string contrasenia){
    
    if(user.Equals("") && contrasenia.Equals("")){
      return BadRequest(new {ok=false,msg ="Usuario/contraseña Incorrecta"});
    }
    var result = await _unitofwork.encargado.Access(user,contrasenia);
    return Ok(new {
      ok = true,
      msg = result
    });
  }

  [HttpGet("{iduser}/destiny")]
  public async Task<ActionResult<EncargadoCamionDTO>> GetDestino(int iduser){

    var result = await _unitofwork.encargado.GetRoutesDestity(iduser);
    if(result == null){
      return BadRequest(new {
        ok = false,
        msg = "Sin Datos"
      });
    }
    var resp = await _trucksProxy.NameRoutes(result.trucks[0].RoutesId);
    return Ok( new {ok = true, msg = resp});
  }
  [HttpPost]
  public async Task<ActionResult> PostEncargado(CreateEncargadoDTO createEncargadoDTO){
    if(ModelState.IsValid){

      var newencargado = _mapper.Map<Encargado>(createEncargadoDTO); 
      await _unitofwork.encargado.Add(newencargado);
      await _unitofwork.CompleteAsync();
      return CreatedAtAction("GetItem", new {id = newencargado.Id}, createEncargadoDTO);
    }
    return new JsonResult("FAIL"){StatusCode =500};

  }
}