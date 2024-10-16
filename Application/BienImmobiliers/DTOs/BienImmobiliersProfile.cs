using AutoMapper;
using Regies.Application.BienImmobiliers.Commands.CreateBienImmo;
using Regies.Application.BienImmobiliers.Commands.UpdateBienImmo;
using Regies.Domain.Model;

namespace Regies.Application.BienImmobiliers.DTOs;

/// <summary>
/// Profile for mapping between BienImmobilier and BienImmobiliersDTOs.
/// </summary>
public class BienImmobiliersProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BienImmobiliersProfile"/> class.
    /// </summary>
    public BienImmobiliersProfile()
    {
        CreateMap<BienImmobilier, BienImmobiliersDTOs>()
            .ForPath(dest => dest.Adresse.Ville, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.Ville))
            .ForPath(dest => dest.Adresse.Rue, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.Rue))
            .ForPath(dest => dest.Adresse.codePostal, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.codePostal))
            .ForPath(dest => dest.Adresse.numeroRue, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.numeroRue))
            .ReverseMap();

        CreateMap<CreateBienImmoCommand, BienImmobilier>()
            .ForPath(dest => dest.Adresse.Ville, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.Ville))
            .ForPath(dest => dest.Adresse.Rue, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.Rue))
            .ForPath(dest => dest.Adresse.codePostal, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.codePostal))
            .ForPath(dest => dest.Adresse.numeroRue, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.numeroRue));

        CreateMap<UpdateBienImmoCommand, BienImmobilier>()
            .ForPath(dest => dest.Adresse.Ville, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.Ville))
            .ForPath(dest => dest.Adresse.Rue, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.Rue))
            .ForPath(dest => dest.Adresse.codePostal, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.codePostal))
            .ForPath(dest => dest.Adresse.numeroRue, opt => opt.MapFrom(src => src.Adresse == null ? null : src.Adresse.numeroRue));
    }
}
