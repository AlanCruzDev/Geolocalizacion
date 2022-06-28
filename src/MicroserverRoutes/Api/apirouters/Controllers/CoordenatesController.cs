using apirouters.Core.IConfiguration;
using apirouters.DTO;
using apirouters.Models;
using apirouters.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
namespace apirouters.Controllers;

[ApiController]
[Route("v1/coordenates")]
public class CoordenatesController : ControllerBase
{
  private readonly IUnitOfWork _unitofwork;
  private readonly IMapper _mapper;
  private readonly IRoutesProxy _routesProxy;
  private readonly IHubContext<RealTime> _hubContext;

  public CoordenatesController(IUnitOfWork unitOfWork, IMapper mapper, IRoutesProxy routesProxy,IHubContext<RealTime> hubContext)
  {
    this._unitofwork = unitOfWork;
    this._mapper = mapper;
    this._routesProxy = routesProxy;
    this._hubContext = hubContext;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult> GetItem(int id){
    var newroutes = await _unitofwork.Coordenate.GetRoutesCoordenates(id);
    return Ok(newroutes);
  }

  [HttpPut("enviar")]
  public async Task<ActionResult> SendCoordenates(CoordenatesDTO coordenatesDTO){
   
    var res = await _unitofwork.Coordenate.Put(coordenatesDTO);
    await _unitofwork.CompleteAsync();
    if(res){
      
    return Ok(new {
      ok=true,
      msg="Actualizacion Completa"
    });
    }
    return new JsonResult("FAIL"){StatusCode =404};
  }

  // Ruta para insertar Pedidos
  [HttpPost]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public async Task<ActionResult> PostCoordenates(CreateNewPackageDTO createNewPackageDTO){
    if (ModelState.IsValid)
    {
      var newcoordenates = _mapper.Map<Coordinates>(createNewPackageDTO);
      
      await _unitofwork.Coordenate.Add(newcoordenates);
      await _unitofwork.CompleteAsync();

      var rolempleado = HttpContext.User.Claims.Where(claim => claim.Type =="id").FirstOrDefault();
      if(rolempleado ==null){
        return NotFound();
      }
      var rol = rolempleado.Value;

     

      // Llamamos al controller RoutesController
      createNewPackageDTO.IdCoordinates = newcoordenates.Id;
      createNewPackageDTO.IdEmploye = Convert.ToInt32(rol);

      await _routesProxy.InsertRoutes(createNewPackageDTO);

      return CreatedAtAction("GetItem", new { id = newcoordenates.Id }, createNewPackageDTO);
    }
    return new JsonResult("Fail") { StatusCode = 500 };
  }  
}

