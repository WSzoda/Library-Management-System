using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles
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
