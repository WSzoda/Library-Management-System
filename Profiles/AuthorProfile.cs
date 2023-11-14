using AutoMapper;
using Biblioteka.Models;
using Biblioteka.Models.DTOs;

namespace Biblioteka.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorResponseDto>();
            CreateMap<AuthorBook, AuthorResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Author!.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Author!.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Author!.Surname));
        }
    }
}
