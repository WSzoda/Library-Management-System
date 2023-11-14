using AutoMapper;
using Biblioteka.Models;
using Biblioteka.Models.DTOs;

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
