using System.Text;
using System.Text.Json;
using apipackages.DTO;
using apipackages.Models;
using Microsoft.Extensions.Options;

namespace apipackages.Services;

public class RoutesProxy : IRoutesProxy{

  private readonly ApiUrls _apiUrls;
  private readonly HttpClient _httpClient;

  public RoutesProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient){
    this._apiUrls=apiUrls.Value;
    this._httpClient=httpClient;
  }

  public async Task<UserDTO> GetEmail(int idUser)
  {
     var request = await _httpClient.GetAsync(string.Format(_apiUrls.CuestomersURL+"v1/user/watch/{0}",idUser));
    if(request.IsSuccessStatusCode){
      var respuestaString = await request.Content.ReadAsStringAsync();
      var emailuser = JsonSerializer.Deserialize<UserDTO>(respuestaString, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
      return emailuser;
    }
    return new UserDTO();
  }

  public async Task InsertDetailPackage(CreateNewPackageDTO createNewPackageDTO)
  {
    var content = new StringContent(
      JsonSerializer.Serialize(createNewPackageDTO),
      Encoding.UTF8,
      "application/json"
    );
    var request = await this._httpClient.PostAsync(this._apiUrls.PackageUrl+"v1/detailpackage",content);
    request.EnsureSuccessStatusCode();
  }
}