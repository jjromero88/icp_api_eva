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

        public async Task<PcmResponse> Insert(Request<List<ResultadoDto>> request)
        {
            try 
            {
                // declaramos la lista de resultados
                List<Resultado> listaResultados = new List<Resultado>();

                // recorremos la lista de resultados
                foreach(var itemRequest in request.entidad)
                {
                    // mapeamos al tipo resultado
                    var entidad = _mapper.Map<Resultado>(itemRequest);

                    // desencriptamos los id
                    entidad.preguntaetapa_id = DencryptOrNull(itemRequest.preguntaetapakey);
                    entidad.entidadetapa_id = DencryptOrNull(itemRequest.entidadetapakey);
                    entidad.alternativa_id = DencryptOrNull(itemRequest.alternativakey);

                    // validamos si tiene medios de verificacion
                    if (itemRequest.lista_medioverificacion?.Count > 0)
                    {
                        List<MedioVerificacion> listaMedioVerificacion = new List<MedioVerificacion>();

                        foreach(var medioRequest in itemRequest.lista_medioverificacion)
                        {
                            // mapeamos el medio de verificacion
                            var entidadMedio = _mapper.Map<MedioVerificacion>(medioRequest);

                            // obtenemos el elemento del documento
                            var documento = medioRequest.verificacion_documento;

                            // guardamos el documento del medio de verificacion y obtenemos las propiedades json
                            entidadMedio.verificacion_doc = documento?.base64content == null ? null : await _unitOfWork.Document.SaveDocumentAsync(documento.filename, documento.base64content, PathKey.DocMedioVerificacion);

                            // agregamos el medio de verificacion
                            listaMedioVerificacion.Add(entidadMedio);
                        }

                        // Convertimos la lista de medios de verificación a JSON
                        entidad.lista_medioverificacion_json = JsonSerializer.Serialize(listaMedioVerificacion);
                    }

                    // agregamos el resultado a la lista de resultados
                    listaResultados.Add(entidad);
                }

                // mapeamos los types de resultados
                var listaresultadosType = _mapper.Map<List<TypeResultado>>(listaResultados);

                // guardamos en base de datos
                var result = _unitOfWork.Resultado.Insert(new Resultado { resultados = listaresultadosType, usuario_reg = _userSessionService.GetUser().username });

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(result.Message);
                }

                _logger.LogInformation(result.Message ?? TransactionMessage.SaveSuccess);
                return ResponseUtil.Created(message: TransactionMessage.SaveSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> Update(Request<List<ResultadoDto>> request)
        {
            throw new NotImplementedException();
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
                    verificacion_documento = item.verificacion_documento,
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

        private int? DencryptOrNull(string? value)
        {
            return string.IsNullOrEmpty(value) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(value, _userSessionService.GetUser().authkey));
        }

    }
}
