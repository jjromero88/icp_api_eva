using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Util.Encryptions;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ResultadoApplication : IResultadoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ResultadoApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public ResultadoApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<ResultadoApplication> logger, 
            IUserSessionService userSessionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList(Request<ResultadoDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Resultado>(request.entidad);

                entidad.resultado_id = string.IsNullOrEmpty(request.entidad.serialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.serialKey, _userSessionService.GetUser().authkey));
                entidad.preguntaetapa_id = string.IsNullOrEmpty(request.entidad.preguntaetapakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.preguntaetapakey, _userSessionService.GetUser().authkey));
                entidad.entidadetapa_id = string.IsNullOrEmpty(request.entidad.entidadetapakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadetapakey, _userSessionService.GetUser().authkey));
                entidad.alternativa_id = string.IsNullOrEmpty(request.entidad.alternativakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.alternativakey, _userSessionService.GetUser().authkey));

                var result = _unitOfWork.Resultado.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                List<Resultado> Lista = new List<Resultado>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Resultado()
                        {
                            serialKey = string.IsNullOrEmpty(item.resultado_id.ToString()) ? null : CShrapEncryption.EncryptString(item.resultado_id.ToString(), _userSessionService.GetUser().authkey),
                            preguntaetapakey = EncryptOrNull(item.preguntaetapa_id.ToString()),
                            entidadetapakey = EncryptOrNull(item.entidadetapa_id.ToString()),
                            alternativakey = EncryptOrNull(item.alternativa_id.ToString()),
                            comentarios = item.comentarios,
                            etapa_nombre = item.etapa_nombre,
                            etapa_descripcion = item.etapa_descripcion,
                            pregunta_numero = item.pregunta_numero,
                            pregunta_descripcion = item.pregunta_descripcion,
                            alternativa_opcion = item.alternativa_opcion,
                            alternativa_descripcion = item.alternativa_descripcion,
                            medioverificacion = item.medioverificacion,
                            lista_medioverificacion = DeserializeMediosVerificacion(item.lista_medioverificacion),
                            estado = item.estado,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<ResultadoResponse>>(_mapper.Map<List<ResultadoDto>>(Lista)),
                    result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        private List<MedioVerificacion> DeserializeMediosVerificacion(string listaMedioverificacion)
        {
            try
            {
                if (string.IsNullOrEmpty(listaMedioverificacion))
                    return new List<MedioVerificacion>();

                var mediosVerificacion = JsonSerializer.Deserialize<List<MedioVerificacion>>(listaMedioverificacion) ?? new List<MedioVerificacion>();
                return mediosVerificacion.Select(item => new MedioVerificacion
                {
                    serialKey = EncryptOrNull(item.medioverificacion_id.ToString()),
                    resultadokey = string.IsNullOrEmpty(item.resultado_id.ToString()) ? null : EncryptOrNull(item.resultado_id.ToString()),
                    verificacion_documento = string.IsNullOrEmpty(item.verificacion_doc) ? null : JsonSerializer.Deserialize<Document>(item.verificacion_doc),
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error en el método DeserializeMediosVerificacion: {ex.Message}", ex);
            }
        }

        private string EncryptOrNull(string value)
        {
            return string.IsNullOrEmpty(value) ? null : CShrapEncryption.EncryptString(value, _userSessionService.GetUser().authkey);
        }

    }
}
