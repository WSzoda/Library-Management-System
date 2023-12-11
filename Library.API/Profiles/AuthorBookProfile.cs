using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles
{
    public class AuthorBookProfile : Profile
    {
        public AuthorBookProfile()
        {
            CreateMap<AuthorBookDto, AuthorBook>();
        }
    }
}
