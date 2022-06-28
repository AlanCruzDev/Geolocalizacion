using System.Text;
using System.Text.Json;
using apirouters.DTO;
using Microsoft.Extensions.Options;

namespace apirouters.Services;
public interface IRoutesProxy{
  Task InsertPackage(CreateNewPackageDTO createPackageDTO);
  Task InsertRoutes(CreateNewPackageDTO createPackageDTO);
}

public class RoutesProxy:IRoutesProxy{
  private readonly ApiUrls _apiUrls;
  private readonly HttpClient _httpClient;

  public RoutesProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient){
    _apiUrls = apiUrls.Value;
    _httpClient= httpClient;
  }
  
  public async Task InsertPackage(CreateNewPackageDTO createPackageDTO){
    var content = new StringContent(
      JsonSerializer.Serialize(createPackageDTO),
      Encoding.UTF8,
      "application/json"
    );
    var request = await _httpClient.PostAsync(_apiUrls.PackageUrl+"v1/package",content);
    request.EnsureSuccessStatusCode();
  }

  public async Task InsertRoutes(CreateNewPackageDTO createPackageDTO){
    var content = new StringContent(
      JsonSerializer.Serialize(createPackageDTO),
      Encoding.UTF8,
      "application/json"
    );
    var request = await _httpClient.PostAsync(_apiUrls.RoutesUrl+"v1/routes",content);
    request.EnsureSuccessStatusCode();
  }
}