using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp.Generics;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AccountService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpSeg:UrlBase"],
              _configuration["Microservices:IcpSeg:Endpoints:Account:Authenticate"]);

                string jsonRequest = JsonSerializer.Serialize(request);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    var httpResponse = await httpClient.PostAsync(url, content);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string responseContent = await httpResponse.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<IcpSegResponse<AuthenticateResponse>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint Authenticate, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new AuthenticateResponse();
                    }
                    else
                    {
                        throw new HttpRequestException($"Error al actualizar el usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"HttpRequestException: {ex.Message}", ex);
            }
        }

        public async Task<AuthorizeResponse> AuthorizeAsync(AuthorizeRequest request)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpSeg:UrlBase"],
              _configuration["Microservices:IcpSeg:Endpoints:Account:Authorize"]);

                string jsonRequest = JsonSerializer.Serialize(request);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    var httpResponse = await httpClient.PostAsync(url, content);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string responseContent = await httpResponse.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<IcpSegResponse<AuthorizeResponse>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint AuthorizeAsync, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new AuthorizeResponse();
                    }
                    else
                    {
                        throw new HttpRequestException($"Error al actualizar el usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"HttpRequestException: {ex.Message}", ex);
            }
        }

        public async Task<List<UsuarioAccesosResponse>> UsuarioAccesosAsync(string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpSeg:UrlBase"],
              _configuration["Microservices:IcpSeg:Endpoints:Account:GetAccesos"]);

                var queryParams = String.Format("{0}", new Uri(url));
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var httpResponse = await httpClient.GetAsync(String.Format(queryParams));

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var responseContent = await httpResponse.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<IcpSegResponse<List<UsuarioAccesosResponse>>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint UsuarioAccesos, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new List<UsuarioAccesosResponse>();
                    }
                    else
                    {
                        throw new HttpRequestException($"Error al obtener la lista de usuarios");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"HttpRequestException: {ex.Message}", ex);
            }
        }

        public async Task<UsuarioPermisosResponse> UsuarioPermisosAsync(UsuarioPermisosrequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpSeg:UrlBase"],
              _configuration["Microservices:IcpSeg:Endpoints:Account:GetPermisos"]);

                string jsonRequest = JsonSerializer.Serialize(request);

                var queryParams = String.Format("{0}?url={1}", new Uri(url), request.url);

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var httpResponse = await httpClient.GetAsync(String.Format(queryParams));

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var responseContent = await httpResponse.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<IcpSegResponse<UsuarioPermisosResponse>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint UsuarioAccesos, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}"); ;

                        return result.Payload ?? new UsuarioPermisosResponse();
                    }
                    else
                    {
                        throw new HttpRequestException($"Error al obtener la lista de usuarios");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"HttpRequestException: {ex.Message}", ex);
            }
        }
    }
}
