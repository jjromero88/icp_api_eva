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
    public class PreguntaEtapaApplication : IPreguntaEtapaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PreguntaEtapaApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public PreguntaEtapaApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<PreguntaEtapaApplication> logger, 
            IUserSessionService userSessionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList(Request<PreguntaEtapaDto> request)
        {
            try
            {
                var entidad = _mapper.Map<PreguntaEtapa>(request.entidad);

                entidad.evaluacionetapa_id = string.IsNullOrEmpty(request.entidad.evaluacionetapakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.evaluacionetapakey, _userSessionService.GetUser().authkey));

                var result = _unitOfWork.PreguntaEtapa.GetList(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                List<PreguntaEtapa> Lista = new List<PreguntaEtapa>();

                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        Lista.Add(new PreguntaEtapa()
                        {
                            serialKey = string.IsNullOrEmpty(item.preguntaetapa_id.ToString()) ? null : CShrapEncryption.EncryptString(item.preguntaetapa_id.ToString(), _userSessionService.GetUser().authkey),
                            evaluacionetapakey = EncryptOrNull(item.evaluacionetapa_id.ToString()),
                            preguntakey = EncryptOrNull(item.pregunta_id.ToString()),
                            pregunta = new Pregunta
                            {
                                serialKey = EncryptOrNull(item.pregunta_id.ToString()),
                                componentekey = EncryptOrNull(item.componente_id.ToString()),
                                etapakey = EncryptOrNull(item.etapa_id.ToString()),
                                codigo = item.codigo,
                                numero = item.numero,
                                descripcion = item.descripcion,
                                calculo_icp = item.calculo_icp,
                                habilitado = item.habilitado,
                                lista_alternativas = DeserializeAlternativas(item.lista_alternativas),
                                etapa = new Etapa
                                {
                                    serialKey = EncryptOrNull(item.etapa_id.ToString()),
                                    codigo = item.etapa_codigo,
                                    nombre = item.etapa_nombre,
                                    abreviatura = item.etapa_abreviatura,
                                    descripcion = item.etapa_descripcion
                                },
                                componente = new Componente
                                {
                                    serialKey = EncryptOrNull(item.componente_id.ToString()),
                                    codigo = item.componente_codigo,
                                    abreviatura = item.componente_abreviatura,
                                    descripcion = item.componente_descripcion
                                },
                                estado = item.estado,
                                usuario_reg = item.usuario_reg,
                                fecha_reg = item.fecha_reg
                            }                            
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<PreguntaEtapaResponse>>(_mapper.Map<List<PreguntaEtapaDto>>(Lista)),
                    result.Message ?? TransactionMessage.QuerySuccess
                    ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        private List<Alternativa> DeserializeAlternativas(string listaAlternativas)
        {
            try
            {
                if (string.IsNullOrEmpty(listaAlternativas))
                    return new List<Alternativa>();

                var alternativas = JsonSerializer.Deserialize<List<Alternativa>>(listaAlternativas) ?? new List<Alternativa>();
                return alternativas.Select(ee => new Alternativa
                {
                    serialKey = EncryptOrNull(ee.alternativa_id.ToString()),
                    preguntakey = EncryptOrNull(ee.pregunta_id.ToString()),
                    codigo = ee.codigo,
                    alternativa = ee.alternativa,
                    descripcion = ee.descripcion,
                    valor = ee.valor,
                    medio_verificacion = ee.medio_verificacion,
                    numero_orden = ee.numero_orden
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error en el método DeserializeAlternativas: {ex.Message}", ex);
            }
        }

        private string EncryptOrNull(string value)
        {
            return string.IsNullOrEmpty(value) ? null : CShrapEncryption.EncryptString(value, _userSessionService.GetUser().authkey);
        }
    }
}
