using apitruck.Core.IConfiguration;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using apitruck.DTO;
using apitruck.Models;
using apitruck.Services;

[ApiController]
[Route("v1/camion")]

public class CamionController:ControllerBase{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  private readonly ITrucksProxy _trucksProxy;
  private readonly IEmailSender _emailSender;

  public CamionController(IUnitOfWork unitOfWork,IMapper mapper, ITrucksProxy trucksProxy, IEmailSender emailSender){
    _unitOfWork = unitOfWork;
    _mapper = mapper;
    _trucksProxy =trucksProxy;
    _emailSender = emailSender;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult>Getitem(int id){
    var result = await _unitOfWork.truck.GetById(id);
    return Ok(result);
  }
  [HttpGet("all")]
  public async Task<ActionResult>GetAll(){
    var result = await _unitOfWork.truck.All();
    return Ok(result);
  }


  [HttpPost]
  public async Task<ActionResult> PostCamion(CreateCamionDTO createCamionDTO){
    if(ModelState.IsValid){
        var newcamion = _mapper.Map<Transport>(createCamionDTO);
        var respuesta = await _unitOfWork.truck.Add(newcamion);
        await _unitOfWork.CompleteAsync();
        if(!respuesta){
          return NotFound(new {
            ok= false,
            msg ="Camion Ya Registrado"
          });      
        }     
        return CreatedAtAction("GetItem", new {id = newcamion.Id}, createCamionDTO);
    }
     return new JsonResult("FAIL"){StatusCode =500};
  }

  // AQUI VAMOS A COMUNICARNOS CON EL MICROSERVIDIO DE PACKAGES Y BUSCSAMOS EL ID DE RUTA DESPUES EL NOMBRE DEL USUARIO Y QUE NOS RETORNET SU CORREO ELECTRONICO

  [HttpPut("update/{idruta}")]
  public async Task<ActionResult> PutTruck(int idruta, PutTruckPackage putTruckPackage){
      var request = await _unitOfWork.truck.PutTruck(idruta,putTruckPackage);
      await _unitOfWork.CompleteAsync();
      if(request){

        //Aqui rescatamos el correo del usuariopiu
        var resultado = await this._trucksProxy.GetitBackEmail(idruta);
        string url = String.Format("http://localhost:4200/follow-up/{0}",idruta);

        // Aqui enviamos el correo electronico
        await this._emailSender.SendEmailAsync(resultado.Email,"Sigue tu Ruta",url);
        
        return Ok(new {
          ok=true,
          msg="Datos Actualizados"
        });
      }    
     return NotFound();        
  }
}