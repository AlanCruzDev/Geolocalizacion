using apirouters.Core.IConfiguration;
using apirouters.DTO;
using apirouters.Models;
using apirouters.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apirouters.Controllers;

[ApiController]
[Route("v1/routes")]
public class RoutesController:ControllerBase{

  private readonly IUnitOfWork _unitofwork;
  private readonly IMapper _mapper;
  private readonly IRoutesProxy _routesProxy;

  public RoutesController(IUnitOfWork unitOfWork, IMapper mapper,IRoutesProxy routesProxy){
    this._unitofwork = unitOfWork;
    this._mapper = mapper;
    this._routesProxy = routesProxy;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult> GetItem(int id){
    var newroutes = await _unitofwork.Routes.GetById(id);
    return Ok(newroutes);
  }


  [HttpGet]
  public async Task<ActionResult> GetRoutes(){
    var newroutes = await _unitofwork.Routes.All();
    return Ok(newroutes);
  }

  [HttpPost]
  public async Task<ActionResult>PostRoutes(CreateNewPackageDTO createNewPackageDTO){
    if(ModelState.IsValid){
      
      var newroutes = _mapper.Map<Routes>(createNewPackageDTO);
      newroutes.coordinatesId = createNewPackageDTO.IdCoordinates;

      await _unitofwork.Routes.Add(newroutes);
      await _unitofwork.CompleteAsync();

      // aqui vamos a ponwer el id nuevo
      createNewPackageDTO.IdRuta = newroutes.Id;

      // Aqui nos comunicamos con el microservice de paquetes
      await _routesProxy.InsertPackage(createNewPackageDTO);

      // Aqui llamamos al otro servicio 
      return CreatedAtAction("GetItem", new {id = newroutes.Id}, createNewPackageDTO);    
    }
    return new JsonResult("Fail"){StatusCode=500};
  }  
}