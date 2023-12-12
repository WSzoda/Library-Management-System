using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreResponseDto>();
            CreateMap<GenreToCreateDto, Genre>();
            CreateMap<GenreResponseDto, Genre>();
        }
    }
}
