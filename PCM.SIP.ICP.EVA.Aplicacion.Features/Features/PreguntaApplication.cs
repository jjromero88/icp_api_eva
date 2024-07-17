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
    public class PreguntaApplication : IPreguntaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PreguntaApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public PreguntaApplication(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppLogger<PreguntaApplication> logger,
            IUserSessionService userSessionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList(Request<PreguntaDto> request)
        {
            try
            {
                var entidad = _mapper.Map<Pregunta>(request.entidad);
                // obtenemos el id de la entidad
                string entidadkey = _userSessionService.GetUser().entidadkey ?? string.Empty;
                // deserializamos los id
                entidad.evaluacionetapa_id = string.IsNullOrEmpty(request.entidad.evaluacionetapakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.evaluacionetapakey, _userSessionService.GetUser().authkey));
                entidad.entidad_id = string.IsNullOrEmpty(entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(entidadkey, _userSessionService.GetUser().authkey));
                // ejecutamos la consulta en bd
                var result = _unitOfWork.Pregunta.GetList(entidad);
                // evaluamos si ocurrió un error
                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }
                // declaramos una lista
                List<Pregunta> Lista = new List<Pregunta>();
                // verificamos que la consulta haya obtenido resultados
                if (result.Data != null)
                {
                    // poblamos la lista con la información obtenida
                    foreach (var item in result.Data)
                    {
                        var componentekey = string.IsNullOrEmpty(item.componente_id == null ? null : item.componente_id.ToString()) ? null : CShrapEncryption.EncryptString(item.componente_id.ToString(), _userSessionService.GetUser().authkey);
                        var etapakey = string.IsNullOrEmpty(item.etapa_id == null ? null : item.etapa_id.ToString()) ? null : CShrapEncryption.EncryptString(item.etapa_id.ToString(), _userSessionService.GetUser().authkey);

                        Lista.Add(new Pregunta()
                        {
                            serialKey = string.IsNullOrEmpty(item.pregunta_id.ToString()) ? null : CShrapEncryption.EncryptString(item.pregunta_id.ToString(), _userSessionService.GetUser().authkey),
                            componentekey = componentekey,
                            etapakey = etapakey,
                            codigo = item.codigo,
                            numero = item.numero,
                            descripcion = item.descripcion,
                            calculo_icp = item.calculo_icp,
                            habilitado = item.habilitado,
                            lista_alternativas = DeserializeAlternativas(item.lista_alternativas),
                            etapa = new Etapa
                            {
                                serialKey = etapakey,
                                codigo = item.etapa_codigo,
                                nombre = item.etapa_nombre,
                                abreviatura = item.etapa_abreviatura,
                                descripcion = item.etapa_descripcion
                            },
                            componente = new Componente
                            {
                                serialKey = componentekey,
                                codigo = item.componente_codigo,
                                abreviatura = item.componente_abreviatura,
                                descripcion = item.componente_descripcion
                            },
                            estado = item.estado,
                            usuario_reg = item.usuario_reg,
                            fecha_reg = item.fecha_reg
                        });
                    }
                }

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(
                    _mapper.Map<List<PreguntaResponse>>(_mapper.Map<List<PreguntaDto>>(Lista)),
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
                    numero_orden = ee.numero_orden,
                    alternativa_resultado = ee.alternativa_resultado,
                    lista_mediosverificacion = DeserializeMediosVerificacion(ee.lista_mediosverificacion)
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error en el método DeserializeAlternativas: {ex.Message}", ex);
            }
        }

        private List<MedioVerificacion> DeserializeMediosVerificacion(List<MedioVerificacion>? listaMediosverificacion)
        {
            try
            {
                if (listaMediosverificacion == null)
                    return new List<MedioVerificacion>();

                return listaMediosverificacion.Select(ee => new MedioVerificacion
                {
                    serialKey = EncryptOrNull(ee.medioverificacion_id.ToString()),
                    resultadokey = EncryptOrNull(ee.resultado_id.ToString()),
                    verificacion_documento = string.IsNullOrEmpty(ee.verificacion_doc) ? null : JsonSerializer.Deserialize<Document>(ee.verificacion_doc)
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
