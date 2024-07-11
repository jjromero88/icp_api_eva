using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account;

namespace PCM.SIP.ICP.EVA.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
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

        }
    }
}
