using System.Text;
using System.Text.Json;
using apipackages.DTO;
using apitruck.DTO;
using apitruck.Models;
using Microsoft.Extensions.Options;

namespace apitruck.Services;
public class TrucksProxy : ITrucksProxy
{

  private readonly ApiUrls _apiUrls;
  private readonly HttpClient _httpClient;

  public TrucksProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient){
    this._apiUrls = apiUrls.Value;
    this._httpClient = httpClient;
  }
  public async Task<RoutesCoordenatesDTO> NameRoutes(int id)
  {
    var request = await _httpClient.GetAsync(string.Format(_apiUrls.RoutesUrl+"v1/coordenates/{0}",id));

    if(request.IsSuccessStatusCode){
      var respuestaString = await request.Content.ReadAsStringAsync();
      var listadoroutas = JsonSerializer.Deserialize<RoutesCoordenatesDTO>(respuestaString,new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
      return listadoroutas;
    }
    return new RoutesCoordenatesDTO();
  }
  
  public async Task<UserDTO> GetitBackEmail(int idroute)
  {
    var request = await _httpClient.GetAsync(string.Format(_apiUrls.PackageUrl+"v1/package/user/email/{0}",idroute));
    if(request.IsSuccessStatusCode){
      var respuestaString = await request.Content.ReadAsStringAsync();
      var emailuser = JsonSerializer.Deserialize<UserDTO>(respuestaString, new JsonSerializerOptions(){PropertyNameCaseInsensitive =true});
      return emailuser;
    }
    return new UserDTO();
  }

}