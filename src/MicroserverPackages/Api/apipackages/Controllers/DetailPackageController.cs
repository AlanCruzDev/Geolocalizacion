using apipackages.Core.IConfiguration;
using apipackages.DTO;
using apipackages.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apipackages.Controllers;

[ApiController]
[Route("v1/detailpackage")]
public class DetailPackageController:ControllerBase{

  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public DetailPackageController(IUnitOfWork unitOfWork, IMapper mapper){
    this._unitOfWork = unitOfWork;
    this._mapper = mapper;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult>GetItem(int id){
    var newdetailpackage = await _unitOfWork.DetailPackage.GetById(id);
    return Ok(newdetailpackage);
  }

  [HttpPost]
  public async Task<ActionResult>PostDetailPackage(CreateNewPackageDTO createNewPackageDTO){

    if(ModelState.IsValid){
      var newdetailpackage = this._mapper.Map<DetailPackage>(createNewPackageDTO);
      newdetailpackage.PackageId =  createNewPackageDTO.PackageId;
      newdetailpackage.EmployesId= createNewPackageDTO.IdEmploye;
      await this._unitOfWork.DetailPackage.Add(newdetailpackage);
      await this._unitOfWork.CompleteAsync();
      return NoContent();
    }
    return new JsonResult("Fail"){StatusCode=500};
  }
}