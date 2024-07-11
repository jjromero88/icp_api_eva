using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Transversal.Common.Constants
{
    public enum HttpStatusCodeEnum
    {
        OK = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        Conflict = 409,
        InternalServerError = 500,
        UnauthorizedHeaderNotFound = 5001,
        UnauthorizedTokenIncorrectFormat = 5003,
        UnauthorizedTokenNotFound = 5002
    }
}
