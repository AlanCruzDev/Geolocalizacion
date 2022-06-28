using apirouters.DTO;
using Microsoft.AspNetCore.SignalR;
namespace apirouters.Services;

public class RealTime: Hub{

  // enviamos el me4nsaje
  public async Task SendMenssage(RoutesTimeDTO routesTimeDTO){
    await Clients.All.SendAsync("ResiveMensaje", routesTimeDTO.latitude);
  }

  // se ejecuta cuando el usuario se conecta
  public override async Task OnConnectedAsync()
  {
    await base.OnConnectedAsync();
  }

}