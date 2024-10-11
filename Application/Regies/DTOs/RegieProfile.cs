using AutoMapper;
using Regies.Domain.Model;

namespace Regies.Application.Regies.DTOs;

public class RegieProfile : Profile
{
    public RegieProfile()
    {
        CreateMap<Regie, RegieDto>()
              .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Adresse.Ville))
              .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Adresse.Rue))
              .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.Adresse.numeroRue))
              .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Adresse.codePostal))
              .ForMember(dest => dest.lesBiensDeLaRegie, opt => opt.MapFrom(src => src.lesBiensDeLaRegie))
              .ReverseMap();
    }
}
