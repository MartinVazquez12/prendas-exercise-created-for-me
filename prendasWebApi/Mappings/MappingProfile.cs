using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security;
using AutoMapper;
using prendasWebApi.Models;
using prendasWebApi.Dtos;

namespace prendasWebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Prenda, PrendaDto>()
            .ForMember(dest => dest.id_prenda, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.nombredto, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.talledto, opt => opt.MapFrom(src => src.Talle))
            .ForMember(dest => dest.colordto, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.nombre_marca, opt => opt.MapFrom(src => src.IdMarcaNavigation.Marca1))
            .ReverseMap();

            CreateMap<Prenda, PrendaPostDto>()
            .ForMember(dest => dest.id_post, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.nombrepost, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.tallepost, opt => opt.MapFrom(src => src.Talle))
            .ForMember(dest => dest.colorpost, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.id_marca, opt => opt.MapFrom(src => src.IdMarca))
            .ReverseMap();

            CreateMap<Marca, MarcaDto>()
            .ForMember(dest => dest.id_marca, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.marcadto, opt => opt.MapFrom(src => src.Marca1))
            .ReverseMap();

        }
    }
}
