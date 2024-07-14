using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public SecurityService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<UsuarioCache> GetSessionDataAsync(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token.Trim()))
                {
                    throw new ArgumentException("El token no puede estar vacío", nameof(token));
                }

                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpSeg:UrlBase"],
              _configuration["Microservices:IcpSeg:Endpoints:Security:GetSessionData"]);

                // formamos los parametros para la peticion
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

                        var result = JsonSerializer.Deserialize<IcpSegResponse<UsuarioCache>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint Authenticate, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new UsuarioCache();
                    }
                    else
                    {
                        throw new HttpRequestException($"Error al obtener los datos de sesión");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"HttpRequestException: {ex.Message}", ex);
            }
        }

        public async Task<bool> ValidateToken(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token.Trim()))
                {
                    throw new ArgumentException("El token no puede estar vacío", nameof(token));
                }

                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpSeg:UrlBase"],
              _configuration["Microservices:IcpSeg:Endpoints:Security:ValidateToken"]);

                // formamos los parametros para la peticion
                var queryParams = String.Format("{0}", new Uri(url));

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var httpResponse = await httpClient.GetAsync(String.Format(queryParams));

                    var statusCode = (int)httpResponse.StatusCode;

                    return statusCode == 200 ? true : false;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error in HTTP request: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}");
            }
        }
    }
}
