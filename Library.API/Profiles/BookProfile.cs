using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookResponseDto>()
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
                .ForMember(dest => dest.Authors, opt => opt.Ignore())  // Ignore Authors property
                .ForMember(dest => dest.Reviews, opt => opt.Ignore()); // Ignore Reviews property
            CreateMap<Book, BookOfAuthorDto>();
        }
    }
}
