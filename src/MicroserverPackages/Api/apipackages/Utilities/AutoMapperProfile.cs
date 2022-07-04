using AutoMapper;
using apipackages.Models;
using apipackages.DTO;

namespace apipackages.Utilities;

public class AutoMapperProfile:Profile{
  public AutoMapperProfile(){

    // origen the destino

    // package 
    CreateMap<CreateNewPackageDTO,Package>();

    // Detailr Package
    CreateMap<CreateNewPackageDTO,DetailPackage>();

    //Empleado
    CreateMap<EmployesDTO,Employes>();
    CreateMap<putEmployeDTO,Employes>();
    
  }
}