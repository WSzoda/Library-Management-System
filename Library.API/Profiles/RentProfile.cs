using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles;

public class RentProfile : Profile
{
    public RentProfile()
    {
        CreateMap<Rental, RentResponseDto>()
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book));
        CreateMap<RentCreateDto, Rental>();
        CreateMap<RentResponseDto, Rental>();
    }
    
}