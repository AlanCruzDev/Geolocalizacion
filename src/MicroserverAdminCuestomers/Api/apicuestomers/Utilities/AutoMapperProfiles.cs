using apicuestomers.DTO;
using apicuestomers.Models;
using AutoMapper;

namespace apicuestomers.Utilities;

public class AutoMapperProfiles:Profile{

  public AutoMapperProfiles(){

    // Origen and Destine

    // Mapping the User
    CreateMap<User,UserDTO>();
    CreateMap<CreateUserDTO, User>();



  }
}