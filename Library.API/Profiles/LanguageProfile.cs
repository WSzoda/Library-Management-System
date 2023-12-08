using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Biblioteka.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Language, LanguageResponseDto>();
            CreateMap<LanguageCreateDto, Language>();
        }
    }
}
