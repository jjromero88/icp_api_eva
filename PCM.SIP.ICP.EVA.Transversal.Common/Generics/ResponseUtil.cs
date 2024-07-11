using FluentValidation.Results;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;

namespace PCM.SIP.ICP.EVA.Transversal.Common.Generics
{
    public class ResponseUtil
    {
        public static PcmResponse BadRequest(IEnumerable<ValidationFailure>? errors = null, string? message = null)
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.BadRequest, Message = message ?? MessageConstant.BadRequest, Payload = errors, error = true };
        }
        public static PcmResponse BadRequest(object? error = null, string? message = null)
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.BadRequest, Message = message ?? MessageConstant.BadRequest, Payload = error, error = true };
        }
        public static PcmResponse InternalError(string? message = null)
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.InternalServerError, Message = string.IsNullOrEmpty(message) ? MessageConstant.InternalError : MessageConstant.InternalError + " " + message, error = true };
        }
        public static PcmResponse Ok(object payload, string? message)
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.OK, Message = message, Payload = payload };
        }
        public static PcmResponse Created(string? message = null)
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.Created, Message = message };
        }
        public static PcmResponse NoContent()
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.NoContent, Message = MessageConstant.NoContentForRequest };
        }
        public static PcmResponse Unauthorized()
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.Unauthorized, Message = MessageConstant.Unauthorized, error = true };
        }
        public static PcmResponse UnauthorizedHeaderNotFound()
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.UnauthorizedHeaderNotFound, Message = MessageConstant.UnauthorizedHeaderNotFound, error = true };
        }
        public static PcmResponse UnauthorizedTokenIncorrectFormat()
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.UnauthorizedTokenIncorrectFormat, Message = MessageConstant.UnauthorizedTokenIncorrectFormat, error = true };
        }
        public static PcmResponse UnauthorizedTokenNotFound()
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.UnauthorizedTokenNotFound, Message = MessageConstant.UnauthorizedTokenNotFound, error = true };
        }
        public static PcmResponse OkUnencrypted(object payload)
        {
            return new PcmResponse { Code = (int)HttpStatusCodeEnum.OK, Payload = payload };
        }
    }
}
