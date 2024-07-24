using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp.Generics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    internal class UbigeoService : IUbigeoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public UbigeoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<DepartamentoResponse>> GetListDepartamentos(string? token)
        {
            try
            {
                if (string.IsNullOrEmpty(token.Trim()))
                {
                    throw new ArgumentException("El token no puede estar vacío", nameof(token));
                }

                string url = String.Format("{0}{1}",
                _configuration["Microservices:IcpAdmin:UrlBase"],
                _configuration["Microservices:IcpAdmin:Endpoints:Ubigeo:Departamentos"]);

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

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<List<DepartamentoResponse>>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint Departamentos, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new List<DepartamentoResponse>();
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

        public async Task<List<ProvinciaResponse>> GetListProvincias(ProvinciaFilterRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
               _configuration["Microservices:IcpAdmin:UrlBase"],
               _configuration["Microservices:IcpAdmin:Endpoints:Ubigeo:Provincias"]);

                string jsonRequest = JsonSerializer.Serialize(request);

                var queryParams = String.Format("{0}?departamento_inei={1}", new Uri(url), request.departamento_inei);

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var httpResponse = await httpClient.GetAsync(String.Format(queryParams));

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var responseContent = await httpResponse.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<List<ProvinciaResponse>>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint Provincias, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new List<ProvinciaResponse>();
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

        public async Task<List<DistritoResponse>> GetListDistritos(DistritoFilterRequest request, string? token)
        {
            try
            {
                string url = String.Format("{0}{1}",
               _configuration["Microservices:IcpAdmin:UrlBase"],
               _configuration["Microservices:IcpAdmin:Endpoints:Ubigeo:Distritos"]);

                string jsonRequest = JsonSerializer.Serialize(request);

                var queryParams = String.Format("{0}?provincia_inei={1}", new Uri(url), request.provincia_inei);

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var httpResponse = await httpClient.GetAsync(String.Format(queryParams));

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var responseContent = await httpResponse.Content.ReadAsStringAsync();

                        var result = JsonSerializer.Deserialize<IcpAdminResponse<List<DistritoResponse>>>(responseContent);

                        if (result == null)
                            throw new HttpRequestException($"Error en endpoint Distritos, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"{result.Message ?? "Ocurió un error en la petición"}");

                        return result.Payload ?? new List<DistritoResponse>();
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
