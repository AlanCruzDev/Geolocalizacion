using apipackages.DTO;
using apirouters.DTO;
using apirouters.Models;
using AutoMapper;

namespace apirouters.Utilities;

public class AutoMapperProfile:Profile{

  public AutoMapperProfile(){

    // origen a destino

    // Coordenates
    CreateMap<CreateNewPackageDTO,Coordinates>();
    CreateMap<Coordinates,CoordenatesDTO>();
    CreateMap<Coordinates,RoutesCoordenatesDTO>();
    CreateMap<CoordenatesDTO, Coordinates>();

    // Routes
    CreateMap<CreateNewPackageDTO,Routes>();
    CreateMap<Routes,RoutesDTO>();
  }
}