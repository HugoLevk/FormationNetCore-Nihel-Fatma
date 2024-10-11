using AutoMapper;
using Regies.Domain.Model;

namespace Regies.Application.BienImmobiliers.DTOs;

public class BienImmobiliersProfile : Profile
{
    public BienImmobiliersProfile()
    {
        CreateMap<BienImmobilier, BienImmobiliersDTOs>()
            .ForPath(dest => dest.Adresse.Ville,      opt => opt.MapFrom(src => src.Adresse == null ? null :  src.Adresse.Ville))
            .ForPath(dest => dest.Adresse.Rue,        opt => opt.MapFrom(src => src.Adresse == null ? null :  src.Adresse.Rue))
            .ForPath(dest => dest.Adresse.codePostal, opt => opt.MapFrom(src => src.Adresse == null ? null :  src.Adresse.codePostal))
            .ForPath(dest => dest.Adresse.numeroRue, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.numeroRue))
            .ReverseMap();
    }
}
