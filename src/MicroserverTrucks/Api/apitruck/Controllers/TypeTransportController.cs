using apitruck.Core.IConfiguration;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using apitruck.DTO;
using apitruck.Models;

[ApiController]
[Route("v1/type")]
public class TypeTransportController:ControllerBase{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

  public TypeTransportController(IUnitOfWork unitOfWork,IMapper mapper){
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult>GetItem(int id){
    var newtransport  = await _unitOfWork.typeTransport.GetById(id);
    return Ok(new {
      ok =true,
      newtransport
    });
  }
  [HttpGet("type/{id}")]
  public async Task<ActionResult> GetTransports(int id){
    var result = await _unitOfWork.typeTransport.GetTypeTransport(id);
    return Ok(result);
  }

  [HttpGet("list/type")]
  public async Task<ActionResult> ListTypes(){
    var reques = await _unitOfWork.typeTransport.All();
    return Ok(reques);
  }
  [HttpPost]
  public async  Task <ActionResult>PostTypeTransport(CreateTypeTransport createTypeTransport){
    if(ModelState.IsValid){

      var typetranposrt = _mapper.Map<TypeTransport>(createTypeTransport);
      await _unitOfWork.typeTransport.Add(typetranposrt);
      await _unitOfWork.CompleteAsync();
      return CreatedAtAction("GetItem", new {id= typetranposrt.Id}, createTypeTransport);

    }
    return new JsonResult("Fail"){
      StatusCode = 500
    };
  }
  
}