using AutoMapper;
using System.Text.Json;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Util.Encryptions;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class EvaluacionApplication : IEvaluacionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EvaluacionApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public EvaluacionApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EvaluacionApplication> logger, 
            IUserSessionService userSessionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList(Request<EvaluacionDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Evaluacion>(request.entidad);

                entidad.evaluacion_id = string.IsNullOrEmpty(request.entidad.serialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.serialKey, _userSessionService.GetUser().authkey));

                var result = _unitOfWork.Evaluacion.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.InternalError(message: result.Message);
                }

                List<Evaluacion> Lista = new List<Evaluacion>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new Evaluacion()
                        {
                            serialKey = string.IsNullOrEmpty(item.evaluacion_id.ToString()) ? null : CShrapEncryption.EncryptString(item.evaluacion_id.ToString(), _userSessionService.GetUser().authkey),
                            codigo = item.codigo,
                            fecha_inicio = item.fecha_inicio,
                            fecha_fin = item.fecha_fin,
                            comentarios = item.comentarios,
                            descripcion = item.descripcion,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg,
                            lista_etapas = DeserializeEtapas(item.lista_etapas)
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<EvaluacionResponse>>(_mapper.Map<List<EvaluacionDto>>(Lista)),
                    result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        private List<EvaluacionEtapa> DeserializeEtapas(string listaEtapas)
        {
            if (string.IsNullOrEmpty(listaEtapas))
            {
                return new List<EvaluacionEtapa>();
            }

            var etapas = JsonSerializer.Deserialize<List<EvaluacionEtapa>>(listaEtapas);
            return etapas.Select(ee => new EvaluacionEtapa
            {
                serialKey = EncryptOrNull(ee.evaluacionetapa_id.ToString()),
                evaluacionkey = EncryptOrNull(ee.evaluacion_id.ToString()),
                etapakey = EncryptOrNull(ee.etapa_id.ToString()),
                fecha_inicio = ee.fecha_inicio,
                fecha_fin = ee.fecha_fin,
                comentarios = ee.comentarios,
                habilitado = ee.habilitado,
                etapa = new Etapa
                {
                    serialKey = EncryptOrNull(ee.evaluacionetapa_id.ToString()),
                    codigo = ee.etapa?.codigo ?? string.Empty,
                    abreviatura = ee.etapa?.abreviatura ?? string.Empty,
                    nombre = ee.etapa?.nombre ?? string.Empty,
                    descripcion = ee.etapa?.descripcion ?? string.Empty
                }
            }).ToList();
        }

        private string EncryptOrNull(string value)
        {
            return string.IsNullOrEmpty(value) ? null : CShrapEncryption.EncryptString(value, _userSessionService.GetUser().authkey);
        }
    }
}
