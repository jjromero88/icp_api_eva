using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;
using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account;

namespace PCM.SIP.ICP.EVA.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            #region Account

            CreateMap<AuthenticateRequest, AuthenticateRequestDto>().ReverseMap()
           .ForMember(destination => destination.username, source => source.MapFrom(src => src.username))
           .ForMember(destination => destination.password, source => source.MapFrom(src => src.password));

            CreateMap<AuthenticateResponse, AuthenticateResponseDto>().ReverseMap()
            .ForMember(destination => destination.idsession, source => source.MapFrom(src => src.idsession))
            .ForMember(destination => destination.username, source => source.MapFrom(src => src.username))
            .ForMember(destination => destination.nombre_completo, source => source.MapFrom(src => src.nombre_completo))
            .ForMember(destination => destination.lista_perfiles, source => source.MapFrom(src => src.lista_perfiles));

            CreateMap<AuthenticatePerfil, AuthenticatePerfilDto>().ReverseMap()
           .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
           .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<AuthorizeRequest, AuthorizeRequestDto>().ReverseMap()
           .ForMember(destination => destination.idsession, source => source.MapFrom(src => src.idsession))
           .ForMember(destination => destination.codigo_perfil, source => source.MapFrom(src => src.codigo_perfil));

            CreateMap<AuthorizeResponse, AuthorizeResponseDto>().ReverseMap()
           .ForMember(destination => destination.token, source => source.MapFrom(src => src.token))
           .ForMember(destination => destination.nombrecompleto, source => source.MapFrom(src => src.nombrecompleto))
           .ForMember(destination => destination.username, source => source.MapFrom(src => src.username))
           .ForMember(destination => destination.perfil, source => source.MapFrom(src => src.perfil))
           .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
           .ForMember(destination => destination.entidad_acronimo, source => source.MapFrom(src => src.entidad_acronimo))
           .ForMember(destination => destination.entidad_nombre, source => source.MapFrom(src => src.entidad_nombre));

            #endregion

            #region Security

            CreateMap<UsuarioAccesosResponse, UsuarioAccesosResponseDto>().ReverseMap()
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.url_opcion, source => source.MapFrom(src => src.url_opcion))
            .ForMember(destination => destination.icono_opcion, source => source.MapFrom(src => src.icono_opcion))
            .ForMember(destination => destination.num_orden, source => source.MapFrom(src => src.num_orden))
            .ForMember(destination => destination.listaAccesos, source => source.MapFrom(src => src.listaAccesos));

            CreateMap<UsuarioPermisosrequest, UsuarioPermisosrequestDto>().ReverseMap()
            .ForMember(destination => destination.url, source => source.MapFrom(src => src.url));

            CreateMap<UsuarioPermisosResponse, UsuarioPermisosResponseDto>().ReverseMap()
            .ForMember(destination => destination.permisos, source => source.MapFrom(src => src.permisos));

            #endregion

            #region Entidad

            CreateMap<EntidadIdRequest, EntidadIdRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey));

            CreateMap<GeneralidadesUpdateRequest, GeneralidadesUpdateRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.ubigeokey, source => source.MapFrom(src => src.ubigeokey))
            .ForMember(destination => destination.documentoestructurakey, source => source.MapFrom(src => src.documentoestructurakey))
            .ForMember(destination => destination.modalidadintegridadkey, source => source.MapFrom(src => src.modalidadintegridadkey))
            .ForMember(destination => destination.modalidadintegridad_anterior, source => source.MapFrom(src => src.modalidadintegridad_anterior))
            .ForMember(destination => destination.documentointegridad_desc, source => source.MapFrom(src => src.documentointegridad_desc))
            .ForMember(destination => destination.num_servidores, source => source.MapFrom(src => src.num_servidores))
            .ForMember(destination => destination.documento_estructura, source => source.MapFrom(src => src.documento_estructura))
            .ForMember(destination => destination.documento_integridad, source => source.MapFrom(src => src.documento_integridad))
            .ForMember(destination => destination.documento_modalidadintegridad, source => source.MapFrom(src => src.documento_modalidadintegridad));

            CreateMap<GeneralidadesFilterRequest, GeneralidadesFilterRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.ubigeokey, source => source.MapFrom(src => src.ubigeokey))
            .ForMember(destination => destination.modalidadintegridadkey, source => source.MapFrom(src => src.modalidadintegridadkey))
            .ForMember(destination => destination.documentoestructurakey, source => source.MapFrom(src => src.documentoestructurakey))
            .ForMember(destination => destination.generalidades, source => source.MapFrom(src => src.generalidades))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<GeneralidadesResponse, GeneralidadesResponseDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.ubigeokey, source => source.MapFrom(src => src.ubigeokey))
            .ForMember(destination => destination.documentoestructurakey, source => source.MapFrom(src => src.documentoestructurakey))
            .ForMember(destination => destination.modalidadintegridadkey, source => source.MapFrom(src => src.modalidadintegridadkey))
            .ForMember(destination => destination.numero_ruc, source => source.MapFrom(src => src.numero_ruc))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.acronimo, source => source.MapFrom(src => src.acronimo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.generalidades, source => source.MapFrom(src => src.generalidades))
            .ForMember(destination => destination.modalidadintegridad_anterior, source => source.MapFrom(src => src.modalidadintegridad_anterior))
            .ForMember(destination => destination.documentointegridad_desc, source => source.MapFrom(src => src.documentointegridad_desc))
            .ForMember(destination => destination.num_servidores, source => source.MapFrom(src => src.num_servidores))
            .ForMember(destination => destination.ubigeo, source => source.MapFrom(src => src.ubigeo))
            .ForMember(destination => destination.modalidadintegridad, source => source.MapFrom(src => src.modalidadintegridad))
            .ForMember(destination => destination.documentoestructura, source => source.MapFrom(src => src.documentoestructura))
            .ForMember(destination => destination.entidadsector, source => source.MapFrom(src => src.entidadsector))
            .ForMember(destination => destination.entidadgrupo, source => source.MapFrom(src => src.entidadgrupo))
            .ForMember(destination => destination.documento_estructura, source => source.MapFrom(src => src.documento_estructura))
            .ForMember(destination => destination.documento_modalidadintegridad, source => source.MapFrom(src => src.documento_modalidadintegridad))
            .ForMember(destination => destination.documento_integridad, source => source.MapFrom(src => src.documento_integridad));

            #endregion

            #region Documento

            CreateMap<Document, DocumentDto>().ReverseMap()
            .ForMember(destination => destination.filename, source => source.MapFrom(src => src.filename))
            .ForMember(destination => destination.category, source => source.MapFrom(src => src.category))
            .ForMember(destination => destination.extension, source => source.MapFrom(src => src.extension))
            .ForMember(destination => destination.size, source => source.MapFrom(src => src.size));

            CreateMap<DocumentDto, DocumentInsertRequestDto>().ReverseMap()
            .ForMember(destination => destination.filename, source => source.MapFrom(src => src.filename))
            .ForMember(destination => destination.base64content, source => source.MapFrom(src => src.base64content));

            CreateMap<DocumentDto, DocumentResponseDto>().ReverseMap()
            .ForMember(destination => destination.category, source => source.MapFrom(src => src.category))
            .ForMember(destination => destination.filename, source => source.MapFrom(src => src.filename))
            .ForMember(destination => destination.extension, source => source.MapFrom(src => src.extension))
            .ForMember(destination => destination.size, source => source.MapFrom(src => src.size));

            CreateMap<DocumentInsertRequest, DocumentInsertRequestDto>().ReverseMap()
            .ForMember(destination => destination.filename, source => source.MapFrom(src => src.filename))
            .ForMember(destination => destination.base64content, source => source.MapFrom(src => src.base64content));

            CreateMap<DocumentResponse, DocumentResponseDto>().ReverseMap()
            .ForMember(destination => destination.category, source => source.MapFrom(src => src.category))
            .ForMember(destination => destination.filename, source => source.MapFrom(src => src.filename))
            .ForMember(destination => destination.extension, source => source.MapFrom(src => src.extension))
            .ForMember(destination => destination.size, source => source.MapFrom(src => src.size));

            #endregion

            #region Ubigeo

            CreateMap<UbigeoEntidadResponse, UbigeoEntidadResponseDto>().ReverseMap()
            .ForMember(destination => destination.departamento_inei, source => source.MapFrom(src => src.departamento_inei))
            .ForMember(destination => destination.provincia_inei, source => source.MapFrom(src => src.provincia_inei))
            .ForMember(destination => destination.departamento, source => source.MapFrom(src => src.departamento))
            .ForMember(destination => destination.provincia, source => source.MapFrom(src => src.provincia))
            .ForMember(destination => destination.distrito, source => source.MapFrom(src => src.distrito));

            #endregion

            #region ModalidadIntegridad

            CreateMap<ModalidadIntegridadEntidadResponse, ModalidadIntegridadEntidadResponseDto>().ReverseMap()
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region DocumentoEstructura

            CreateMap<DocumentoEstructuraEntidadResponse, DocumentoEstructuraEntidadResponseDto>().ReverseMap()
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region EntidadSector

            CreateMap<EntidadSectorEntidadResponse, EntidadSectorEntidadResponseDto>().ReverseMap()
           .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
           .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
           .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region EntidadGrupo

            CreateMap<EntidadGrupoEntidadResponse, EntidadGrupoEntidadResponseDto>().ReverseMap()
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region ModalidadContrato

            CreateMap<ModalidadContratoResponse, ModalidadContratoResponseDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region Profesion

            CreateMap<ProfesionResponse, ProfesionResponseDto>().ReverseMap()
           .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
           .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
           .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));


            #endregion

            #region EntidadOficial

            CreateMap<EntidadOficialIdRequest, EntidadOficialIdRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey));

            CreateMap<EntidadOficialInsertRequest, EntidadOficialInsertRequestDto>().ReverseMap()
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion));

            CreateMap<EntidadOficialUpdateRequest, EntidadOficialUpdateRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion));

            CreateMap<EntidadOficialFilterRequest, EntidadOficialFilterRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<EntidadOficialResponse, EntidadOficialResponseDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion))
            .ForMember(destination => destination.profesion, source => source.MapFrom(src => src.profesion))
            .ForMember(destination => destination.modalidadcontrato, source => source.MapFrom(src => src.modalidadcontrato));

            #endregion

            #region EntidadCoordinador

            CreateMap<EntidadCoordinadorIdRequest, EntidadCoordinadorIdRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey));

            CreateMap<EntidadCoordinadorInsertRequest, EntidadCoordinadorInsertRequestDto>().ReverseMap()
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion));

            CreateMap<EntidadCoordinadorUpdateRequest, EntidadCoordinadorUpdateRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual));

            CreateMap<EntidadCoordinadorFilterRequest, EntidadCoordinadorFilterRequestDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<EntidadCoordinadorResponse, EntidadCoordinadorResponseDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion))
            .ForMember(destination => destination.profesion, source => source.MapFrom(src => src.profesion))
            .ForMember(destination => destination.modalidadcontrato, source => source.MapFrom(src => src.modalidadcontrato));

            #endregion

            #region Evaluacion

            CreateMap<Evaluacion, EvaluacionDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.vigente, source => source.MapFrom(src => src.vigente));

            CreateMap<EvaluacionDto, EvaluacionFilterRequest>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<EvaluacionDto, EvaluacionResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.vigente, source => source.MapFrom(src => src.vigente));

            #endregion

            #region EvaluacionEtapa

            CreateMap<EvaluacionEtapa, EvaluacionEtapaDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.evaluacionkey, source => source.MapFrom(src => src.evaluacionkey))
            .ForMember(destination => destination.etapakey, source => source.MapFrom(src => src.etapakey))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
            .ForMember(destination => destination.vigente, source => source.MapFrom(src => src.vigente))
            .ForMember(destination => destination.etapa, source => source.MapFrom(src => src.etapa))
            .ForMember(destination => destination.evaluacion, source => source.MapFrom(src => src.evaluacion))
            .ForMember(destination => destination.entidadetapa, source => source.MapFrom(src => src.entidadetapa));

            CreateMap<EvaluacionEtapaDto, EvaluacionEtapaResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.evaluacionkey, source => source.MapFrom(src => src.evaluacionkey))
            .ForMember(destination => destination.etapakey, source => source.MapFrom(src => src.etapakey))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
            .ForMember(destination => destination.vigente, source => source.MapFrom(src => src.vigente))
            .ForMember(destination => destination.etapa, source => source.MapFrom(src => src.etapa))
            .ForMember(destination => destination.evaluacion, source => source.MapFrom(src => src.evaluacion))
            .ForMember(destination => destination.entidadetapa, source => source.MapFrom(src => src.entidadetapa));

            #endregion

            #region Etapa

            CreateMap<Etapa, EtapaDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<EtapaDto, EtapaResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region Pregunta

            CreateMap<Pregunta, PreguntaDto>().ReverseMap()
           .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
           .ForMember(destination => destination.componentekey, source => source.MapFrom(src => src.componentekey))
           .ForMember(destination => destination.etapakey, source => source.MapFrom(src => src.etapakey))
           .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
           .ForMember(destination => destination.numero, source => source.MapFrom(src => src.numero))
           .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
           .ForMember(destination => destination.calculo_icp, source => source.MapFrom(src => src.calculo_icp))
           .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
           .ForMember(destination => destination.etapa, source => source.MapFrom(src => src.etapa))
           .ForMember(destination => destination.componente, source => source.MapFrom(src => src.componente))
           .ForMember(destination => destination.lista_alternativas, source => source.MapFrom(src => src.lista_alternativas));

           
            CreateMap<PreguntaDto, PreguntaResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.etapakey, source => source.MapFrom(src => src.etapakey))
            .ForMember(destination => destination.componentekey, source => source.MapFrom(src => src.componentekey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.numero, source => source.MapFrom(src => src.numero))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.calculo_icp, source => source.MapFrom(src => src.calculo_icp))
            .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
            .ForMember(destination => destination.etapa, source => source.MapFrom(src => src.etapa))
            .ForMember(destination => destination.componente, source => source.MapFrom(src => src.componente))
            .ForMember(destination => destination.lista_alternativas, source => source.MapFrom(src => src.lista_alternativas));


            #endregion

            #region Etapa

            CreateMap<Etapa, EtapaDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<EtapaDto, EtapaResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region Componente

            CreateMap<Componente, ComponenteDto>().ReverseMap()
           .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
           .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
           .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
           .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<ComponenteDto, ComponenteResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));


            #endregion

            #region Alternativa

            CreateMap<Alternativa, AlternativaDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.preguntakey, source => source.MapFrom(src => src.preguntakey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.alternativa, source => source.MapFrom(src => src.alternativa))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.valor, source => source.MapFrom(src => src.valor))
            .ForMember(destination => destination.medio_verificacion, source => source.MapFrom(src => src.medio_verificacion))
            .ForMember(destination => destination.numero_orden, source => source.MapFrom(src => src.numero_orden));

            CreateMap<AlternativaDto, AlternativaResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.alternativa, source => source.MapFrom(src => src.alternativa))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.valor, source => source.MapFrom(src => src.valor))
            .ForMember(destination => destination.medio_verificacion, source => source.MapFrom(src => src.medio_verificacion))
            .ForMember(destination => destination.numero_orden, source => source.MapFrom(src => src.numero_orden));

            #endregion

            #region MedioVerificacion

            CreateMap<MedioVerificacion, MedioVerificacionDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.resultadokey, source => source.MapFrom(src => src.resultadokey))
            .ForMember(destination => destination.verificacion_doc, source => source.MapFrom(src => src.verificacion_doc))
            .ForMember(destination => destination.fecha_reg, source => source.MapFrom(src => src.fecha_reg))
            .ForMember(destination => destination.verificacion_documento, source => source.MapFrom(src => src.verificacion_documento));

            CreateMap<MedioVerificacionDto, MedioVerificacionInsertRequest>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.resultadokey, source => source.MapFrom(src => src.resultadokey))
            .ForMember(destination => destination.verificacion_documento, source => source.MapFrom(src => src.verificacion_documento));

            CreateMap<MedioVerificacionDto, MedioVerificacionResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.resultadokey, source => source.MapFrom(src => src.resultadokey))
            .ForMember(destination => destination.fecha_reg, source => source.MapFrom(src => src.fecha_reg))
            .ForMember(destination => destination.verificacion_documento, source => source.MapFrom(src => src.verificacion_documento));

            #endregion

            #region EntidadEtapa

            CreateMap<EntidadEtapa, EntidadEtapaDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.evaluacionetapakey, source => source.MapFrom(src => src.evaluacionetapakey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.fichaestado, source => source.MapFrom(src => src.fichaestado))
            .ForMember(destination => destination.fichahistorico, source => source.MapFrom(src => src.fichahistorico));

            CreateMap<EntidadEtapaDto, EntidadEtapaResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.evaluacionetapakey, source => source.MapFrom(src => src.evaluacionetapakey))
            .ForMember(destination => destination.fichaestado, source => source.MapFrom(src => src.fichaestado))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey));

            CreateMap<EntidadEtapaDto, GenerarFichaRequest>().ReverseMap()
           .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
           .ForMember(destination => destination.fichahistorico, source => source.MapFrom(src => src.fichahistorico));

            CreateMap<EntidadEtapaDto, AprobarFichaRequest>().ReverseMap()
           .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
           .ForMember(destination => destination.fichahistorico, source => source.MapFrom(src => src.fichahistorico));

            CreateMap<EntidadEtapaDto, FirmarFichaRequest>().ReverseMap()
           .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
           .ForMember(destination => destination.fichahistorico, source => source.MapFrom(src => src.fichahistorico));

            #endregion

            #region PreguntaEtapa

            CreateMap<PreguntaEtapa, PreguntaEtapaDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.evaluacionetapakey, source => source.MapFrom(src => src.evaluacionetapakey))
            .ForMember(destination => destination.preguntakey, source => source.MapFrom(src => src.preguntakey))
            .ForMember(destination => destination.pregunta, source => source.MapFrom(src => src.pregunta));

            CreateMap<PreguntaEtapaDto, PreguntaEtapaFilterRequest>().ReverseMap()
           .ForMember(destination => destination.evaluacionetapakey, source => source.MapFrom(src => src.evaluacionetapakey));

            CreateMap<PreguntaEtapaDto, PreguntaEtapaResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.evaluacionetapakey, source => source.MapFrom(src => src.evaluacionetapakey))
            .ForMember(destination => destination.preguntakey, source => source.MapFrom(src => src.preguntakey))
            .ForMember(destination => destination.pregunta, source => source.MapFrom(src => src.pregunta));

            #endregion

            #region Resultado

            CreateMap<Resultado, ResultadoDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.preguntaetapakey, source => source.MapFrom(src => src.preguntaetapakey))
            .ForMember(destination => destination.entidadetapakey, source => source.MapFrom(src => src.entidadetapakey))
            .ForMember(destination => destination.alternativakey, source => source.MapFrom(src => src.alternativakey))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.etapa_nombre, source => source.MapFrom(src => src.etapa_nombre))
            .ForMember(destination => destination.etapa_descripcion, source => source.MapFrom(src => src.etapa_descripcion))
            .ForMember(destination => destination.pregunta_numero, source => source.MapFrom(src => src.pregunta_numero))
            .ForMember(destination => destination.pregunta_descripcion, source => source.MapFrom(src => src.pregunta_descripcion))
            .ForMember(destination => destination.alternativa_opcion, source => source.MapFrom(src => src.alternativa_opcion))
            .ForMember(destination => destination.alternativa_descripcion, source => source.MapFrom(src => src.alternativa_descripcion))
            .ForMember(destination => destination.fecha_reg, source => source.MapFrom(src => src.fecha_reg))
            .ForMember(destination => destination.medioverificacion, source => source.MapFrom(src => src.medioverificacion))
            .ForMember(destination => destination.lista_medioverificacion, source => source.MapFrom(src => src.lista_medioverificacion));

            CreateMap<Resultado, TypeResultado>().ReverseMap()
            .ForMember(destination => destination.resultado_id, source => source.MapFrom(src => src.resultado_id))
            .ForMember(destination => destination.preguntaetapa_id, source => source.MapFrom(src => src.preguntaetapa_id))
            .ForMember(destination => destination.entidadetapa_id, source => source.MapFrom(src => src.entidadetapa_id))
            .ForMember(destination => destination.alternativa_id, source => source.MapFrom(src => src.alternativa_id))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.etapa_nombre, source => source.MapFrom(src => src.etapa_nombre))
            .ForMember(destination => destination.etapa_descripcion, source => source.MapFrom(src => src.etapa_descripcion))
            .ForMember(destination => destination.pregunta_numero, source => source.MapFrom(src => src.pregunta_numero))
            .ForMember(destination => destination.pregunta_descripcion, source => source.MapFrom(src => src.pregunta_descripcion))
            .ForMember(destination => destination.alternativa_opcion, source => source.MapFrom(src => src.alternativa_opcion))
            .ForMember(destination => destination.alternativa_descripcion, source => source.MapFrom(src => src.alternativa_descripcion))
            .ForMember(destination => destination.medioverificacion, source => source.MapFrom(src => src.medioverificacion))
            .ForMember(destination => destination.lista_medioverificacion_json, source => source.MapFrom(src => src.lista_medioverificacion_json));

            CreateMap<ResultadoDto, ResultadoInsertRequest>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.preguntaetapakey, source => source.MapFrom(src => src.preguntaetapakey))
            .ForMember(destination => destination.entidadetapakey, source => source.MapFrom(src => src.entidadetapakey))
            .ForMember(destination => destination.alternativakey, source => source.MapFrom(src => src.alternativakey))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.etapa_nombre, source => source.MapFrom(src => src.etapa_nombre))
            .ForMember(destination => destination.etapa_descripcion, source => source.MapFrom(src => src.etapa_descripcion))
            .ForMember(destination => destination.pregunta_numero, source => source.MapFrom(src => src.pregunta_numero))
            .ForMember(destination => destination.pregunta_descripcion, source => source.MapFrom(src => src.pregunta_descripcion))
            .ForMember(destination => destination.alternativa_opcion, source => source.MapFrom(src => src.alternativa_opcion))
            .ForMember(destination => destination.alternativa_descripcion, source => source.MapFrom(src => src.alternativa_descripcion))
            .ForMember(destination => destination.medioverificacion, source => source.MapFrom(src => src.medioverificacion))
            .ForMember(destination => destination.lista_medioverificacion, source => source.MapFrom(src => src.lista_medioverificacion));

            CreateMap<ResultadoDto, ResultadoFilterRequest>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.preguntaetapakey, source => source.MapFrom(src => src.preguntaetapakey))
            .ForMember(destination => destination.entidadetapakey, source => source.MapFrom(src => src.entidadetapakey))
            .ForMember(destination => destination.alternativakey, source => source.MapFrom(src => src.alternativakey));

            CreateMap<ResultadoDto, ResultadoResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.preguntaetapakey, source => source.MapFrom(src => src.preguntaetapakey))
            .ForMember(destination => destination.entidadetapakey, source => source.MapFrom(src => src.entidadetapakey))
            .ForMember(destination => destination.alternativakey, source => source.MapFrom(src => src.alternativakey))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.etapa_nombre, source => source.MapFrom(src => src.etapa_nombre))
            .ForMember(destination => destination.etapa_descripcion, source => source.MapFrom(src => src.etapa_descripcion))
            .ForMember(destination => destination.pregunta_numero, source => source.MapFrom(src => src.pregunta_numero))
            .ForMember(destination => destination.pregunta_descripcion, source => source.MapFrom(src => src.pregunta_descripcion))
            .ForMember(destination => destination.alternativa_opcion, source => source.MapFrom(src => src.alternativa_opcion))
            .ForMember(destination => destination.alternativa_descripcion, source => source.MapFrom(src => src.alternativa_descripcion))
            .ForMember(destination => destination.fecha_reg, source => source.MapFrom(src => src.fecha_reg))
            .ForMember(destination => destination.medioverificacion, source => source.MapFrom(src => src.medioverificacion))
            .ForMember(destination => destination.lista_medioverificacion, source => source.MapFrom(src => src.lista_medioverificacion));

            #endregion

            #region FichaHistorico

            CreateMap<FichaHistorico, FichaHistoricoDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.entidadetapakey, source => source.MapFrom(src => src.entidadetapakey))
            .ForMember(destination => destination.estadoanteriorkey, source => source.MapFrom(src => src.estadoanteriorkey))
            .ForMember(destination => destination.estadonuevokey, source => source.MapFrom(src => src.estadonuevokey))
            .ForMember(destination => destination.usuariokey, source => source.MapFrom(src => src.usuariokey))
            .ForMember(destination => destination.perfilkey, source => source.MapFrom(src => src.perfilkey))
            .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<FichaHistoricoDto, GenerarFichaHistoricoRequest>().ReverseMap()
           .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios));

            CreateMap<FichaHistoricoDto, AprobarFichaHistoricoRequest>().ReverseMap()
           .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios));

            CreateMap<FichaHistoricoDto, FirmarFichaHistoricoRequest>().ReverseMap()
           .ForMember(destination => destination.comentarios, source => source.MapFrom(src => src.comentarios))
           .ForMember(destination => destination.ficha_documento, source => source.MapFrom(src => src.ficha_documento));

            #endregion

            #region FichaEstados

            CreateMap<FichaEstados, FichaEstadosDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<FichaEstadosDto, FichaEstadosResponse>().ReverseMap()
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region Report

            CreateMap<ReportDataDto, ReporteAgrupadoPorEtapasRequest>().ReverseMap()
            .ForMember(destination => destination.evaluacionkey, source => source.MapFrom(src => src.evaluacionkey))
            .ForMember(destination => destination.etapakey, source => source.MapFrom(src => src.etapakey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey));

            CreateMap<ReporteAgrupadoPorEtapasResponse, TotalEntidadesResponse>().ReverseMap()
            .ForMember(destination => destination.etapa, source => source.MapFrom(src => src.etapa))
            .ForMember(destination => destination.avance, source => source.MapFrom(src => src.avance))
            .ForMember(destination => destination.brecha, source => source.MapFrom(src => src.brecha));

            CreateMap<ReportDataDto, ReporteGrupoEntidadesRequest>().ReverseMap()
            .ForMember(destination => destination.evaluacionkey, source => source.MapFrom(src => src.evaluacionkey))
            .ForMember(destination => destination.etapakey, source => source.MapFrom(src => src.etapakey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey));

            CreateMap<ReporteGrupoEntidadesResponse, GrupoEntidadesResponse>().ReverseMap()
            .ForMember(destination => destination.grupo, source => source.MapFrom(src => src.grupo))
            .ForMember(destination => destination.etapa_abreviatura, source => source.MapFrom(src => src.etapa_abreviatura))
            .ForMember(destination => destination.etapa_nombre, source => source.MapFrom(src => src.etapa_nombre))
            .ForMember(destination => destination.avance, source => source.MapFrom(src => src.avance))
            .ForMember(destination => destination.brecha, source => source.MapFrom(src => src.brecha));

            #endregion

        }
    }
}
