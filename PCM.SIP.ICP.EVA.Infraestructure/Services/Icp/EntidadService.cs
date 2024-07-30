using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp.Generics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    public class EntidadService : IEntidadService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public EntidadService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

 
        public async Task<List<EntidadResponse>> GetListEntidad(EntidadFilterRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:Entidad:GetList"]);

                string jsonRequest = JsonSerializer.Serialize(request);

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

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<List<EntidadResponse>>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint GetByIdGeneralidades, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new List<EntidadResponse>();
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


        public async Task<GeneralidadesResponse> GetByIdGeneralidades(EntidadIdRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:EntidadGeneralidades:GetById"]);

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

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<GeneralidadesResponse>>(responseContent);


                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint GetByIdGeneralidades, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new GeneralidadesResponse();
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

        public async Task<List<GeneralidadesResponse>> GetListGeneralidades(GeneralidadesFilterRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:EntidadGeneralidades:GetList"]);

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

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<List<GeneralidadesResponse>>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint GetByIdGeneralidades, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new List<GeneralidadesResponse>();
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

        public async Task<object?> UpdateGeneralidades(GeneralidadesUpdateRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:EntidadGeneralidades:Update"]);

                string jsonRequest = JsonSerializer.Serialize(request);

                using (var httpClient = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    var httpResponse = await httpClient.PutAsync(url, content);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string responseContent = await httpResponse.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<object>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint UpdateGeneralidades, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload;
                    }
                    else
                    {
                        string errorContent = await httpResponse.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Error al actualizar el usuario: {errorContent}");
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
