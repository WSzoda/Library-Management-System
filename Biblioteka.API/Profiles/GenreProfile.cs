using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Biblioteka.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreResponseDto>();
        }
    }
}
