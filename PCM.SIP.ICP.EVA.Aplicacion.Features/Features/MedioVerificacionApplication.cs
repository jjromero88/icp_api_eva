using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Aplicacion.Validator;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class MedioVerificacionApplication : IMedioVerificacionApplication
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<MedioVerificacionApplication> _logger;
        private readonly IRedisCacheService _redisCacheService;
        private readonly MedioVerificacionValidationManager _medioVerificacionValidationManager;

        public MedioVerificacionApplication(
            IMapper mapper,
            IAppLogger<MedioVerificacionApplication> logger,
            IRedisCacheService redisCacheService,
            MedioVerificacionValidationManager medioVerificacionValidationManager)
        {
            _mapper = mapper;
            _logger = logger;
            _redisCacheService = redisCacheService;
            _medioVerificacionValidationManager = medioVerificacionValidationManager;
        }

        public async Task<PcmResponse> UploadDocument(MedioVerificacionDocumentUploadRequest request)
        {
            try
            {
                // ejecutamos las validaciones
                var validation = _medioVerificacionValidationManager.Validate(request);

                if (!validation.IsValid)
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);

                //generamos un id para el documento
                var idCacheDocument = Guid.NewGuid().ToString();

                //guardamos los datos obtenidos del usuario en redis cache
                await _redisCacheService.SetAsync(idCacheDocument, request, 
                    ApplicationKeys.medioVerificacionDocumentAbsoluteExpiration, 
                    ApplicationKeys.medioVerificacionDocumentSlidingExpiration);

                //retornamos la informacion
                return ResponseUtil.Ok(new MedioVerificacionDocumentUploadResponse { filekey = idCacheDocument }
                                      , TransactionMessage.SaveSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }
    }
}
