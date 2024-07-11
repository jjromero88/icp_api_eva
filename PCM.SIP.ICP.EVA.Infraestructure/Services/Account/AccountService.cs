using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

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

                        var result = JsonSerializer.Deserialize<AccountResponse<AuthenticateResponse>>(responseContent);

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

                        var result = JsonSerializer.Deserialize<AccountResponse<AuthorizeResponse>>(responseContent);

                        if (result == null || result.Payload == null)
                            throw new HttpRequestException($"Error en endpoint Authenticate, no se obtuvieron resultados");

                        if (result.Error)
                            throw new ArgumentException($"ArgumentException: {result.Message ?? "Ocurió un error en la petición"}");

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
        private class AccountResponse<T>
        {
            [JsonPropertyName("code")]
            public int Code { get; set; }

            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonPropertyName("error")]
            public bool Error { get; set; }

            [JsonPropertyName("payload")]
            public T? Payload { get; set; }
        }
    }
}
