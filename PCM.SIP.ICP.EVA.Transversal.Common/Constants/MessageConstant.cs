
namespace PCM.SIP.ICP.EVA.Transversal.Common.Constants
{
    public static class MessageConstant
    {
        public static string BadRequest = "Se ha encontrado errores en la petición.";
        public static string InternalError = "Ha ocurrido un error, por favor vuelva a intentar.";
        public static string NoContentForRequest = "No se han encontrado datos para su petición.";
        public static string Unauthorized = "No se encuentra authorizado para su petición.";
        public static string UnauthorizedHeaderNotFound = "No se ha encontrado parámetro Authorization en la cabecera de la solicitud.";
        public static string UnauthorizedTokenIncorrectFormat = "Formato incorrecto de parámetro Authorization en la cabecera de la solicitud, 'Bearer ' es requerido.";
        public static string UnauthorizedTokenNotFound = "No se ha encontrado Token en la cabecera del Request.";
    }
    public static class Validation
    {
        public const string InvalidMessage = "Errores de validación.";
    }
    public static class TransactionMessage
    {
        public const string SaveSuccess = "La informacion ha sido registrada satisfactoriamente";
        public const string UpdateSuccess = "La informacion ha sido actualizada satisfactoriamente";
        public const string DeleteSuccess = "La informacion ha sido eliminada satisfactoriamente";
        public const string QuerySuccess = "Consulta exitosa.";
        public const string GeneralSuccess = "Operacion exitosa.";
        public const string NoResults = "La consulta no obtuvo resultados.";
    }
    public static class AuthenticateMessage
    {
        public const string AuthenticateSuccess = "Ingreso exitoso";
    }
    public static class PathKey
    {
        public const string DocEstructura = "EstructuraPath";
        public const string DocModalidadIntegridad = "ModalidadIntegridadPath";
        public const string DocIntegridad = "DocumentoIntegridad";
        public const string DocDesignacionOficial = "DocumentoDesignacionOficial";
        public const string DocDesignacionCoordinador = "DocumentoDesignacionCoordinador";
        public const string DocAsistenciaTecnica = "DocumentoAsistenciaTecnica";
        public const string DocMedioVerificacion = "DocMedioVerificacion";
        public const string DocFirmaOficialIntegridad = "DocFirmaOficialIntegridad";
    }
}
