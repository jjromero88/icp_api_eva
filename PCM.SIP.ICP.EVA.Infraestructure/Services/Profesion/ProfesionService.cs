using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp.Generics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    public class ProfesionService : IProfesionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProfesionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<ProfesionResponse>> GetList(ProfesionFilterRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:Profesion:GetList"]);

                string jsonRequest = JsonSerializer.Serialize(request);

                var queryParams = String.Format("{0}?serialKey={1}", new Uri(url), request.serialKey);

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var httpResponse = await httpClient.GetAsync(String.Format(queryParams));

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var responseContent = await httpResponse.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<List<ProfesionResponse>>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint GteListModalidadIntegridad, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new List<ProfesionResponse>();
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
