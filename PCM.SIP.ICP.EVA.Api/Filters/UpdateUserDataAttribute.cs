using Microsoft.AspNetCore.Mvc.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Api.Filters
{
    public class UpdateUserDataAttribute : ActionFilterAttribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            // obtenemos el token del header
            string token = context.HttpContext.Request.Headers["Authorization"];

            // If no authorization header found, nothing to process further
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("El token no puede estar vacío");
            }

            // If no content Bearer in Authorization Header
            if (!token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("El token no tiene el formato correcto");
            }
            else
                // seteamos el valor del token
                token = token.Substring("Bearer ".Length).Trim();

            //obtenemos el servicio de seguridad
            var securityService = context.HttpContext.RequestServices.GetService<ISecurityService>();

            // consumimos el servicio de seguridad que obtiene datos del usuario
            var usuarioCache = await securityService?.GetSessionDataAsync(token.ToString());

            // verificamos que el usuario obtenido no sea nulo
            if (usuarioCache == null)
            {
                throw new Exception("La información del usuario no ha sido encontrada");
            }

            // obtenemos el servicio de usuario
            var userSessionService = context.HttpContext.RequestServices.GetService<IUserSessionService>();

            // serializamos a json
            string jsonStringUsuario = JsonSerializer.Serialize(usuarioCache);

            // actualizamos al usuario de sesion
            userSessionService.SetUser(jsonStringUsuario);

            // actualizamos el token
            userSessionService.SetToken(token);

            await next();
        }

    }
}
