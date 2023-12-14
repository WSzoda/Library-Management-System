using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles;

public class RentProfile : Profile
{
    public RentProfile()
    {
        CreateMap<Rental, RentResponseDto>();
        CreateMap<RentCreateDto, Rental>();
        CreateMap<RentResponseDto, Rental>();
    }
    
}