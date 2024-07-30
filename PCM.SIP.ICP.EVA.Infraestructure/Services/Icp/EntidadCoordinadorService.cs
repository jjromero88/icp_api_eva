using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp.Generics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    public class EntidadCoordinadorService : IEntidadCoordinadorService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public EntidadCoordinadorService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public Task<PcmResponse> GetList(Request<EntidadCoordinadorFilterRequest> request, string? token)
        {
            throw new NotImplementedException();
        }

        public async Task<object?> Insert(EntidadCoordinadorInsertRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:EntidadCoordinador:Insert"]);

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
                            throw new HttpRequestException($"Error en endpoint EntidadCoordinador/Insert, no se obtuvieron resultados");

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

        public async Task<object?> Update(EntidadCoordinadorUpdateRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:EntidadCoordinador:Update"]);

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
                            throw new HttpRequestException($"Error en endpoint EntidadCoordinador/Update, no se obtuvieron resultados");

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

        public async Task<object?> Delete(EntidadCoordinadorIdRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:EntidadCoordinador:Delete"]);

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
                            throw new HttpRequestException($"Error en endpoint EntidadCoordinador/Delete, no se obtuvieron resultados");

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

        public async Task<EntidadCoordinadorResponse> GetById(EntidadCoordinadorIdRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:EntidadCoordinador:GetById"]);

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

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<EntidadCoordinadorResponse>>(responseContent);


                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint EntidadCoordinador/GetById, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new EntidadCoordinadorResponse();
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

        public async Task<List<EntidadCoordinadorResponse>> GetList(EntidadCoordinadorFilterRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
              _configuration["Microservices:IcpAdmin:Endpoints:EntidadCoordinador:GetList"]);

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

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<List<EntidadCoordinadorResponse>>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint EntidadCoordinador/GetList, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new List<EntidadCoordinadorResponse>();
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
