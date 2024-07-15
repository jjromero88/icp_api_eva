using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Dto.Dto.icp;
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

        }
    }
}
