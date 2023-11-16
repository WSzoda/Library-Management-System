using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Biblioteka.Profiles
{
    public class AuthorBookProfile : Profile
    {
        public AuthorBookProfile()
        {
            CreateMap<AuthorBookDto, AuthorBook>();
        }
    }
}
