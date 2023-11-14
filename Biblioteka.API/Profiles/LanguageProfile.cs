using AutoMapper;
using Biblioteka.Models;
using Biblioteka.Models.DTOs;

namespace Biblioteka.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Language, LanguageResponseDto>();
        }
    }
}
