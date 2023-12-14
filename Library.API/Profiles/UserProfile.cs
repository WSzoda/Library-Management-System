using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
        CreateMap<UserResponseDto, User>();
    }
}