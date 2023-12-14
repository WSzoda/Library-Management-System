using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Language, LanguageResponseDto>();
            CreateMap<LanguageCreateDto, Language>();
            CreateMap<LanguageResponseDto, Language>();
        }
    }
}
