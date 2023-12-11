using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryResponseDto>();
        CreateMap<CountryCreateDto, Country>();
    }
    
}