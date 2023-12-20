using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherResponseDto>();
            CreateMap<PublisherCreateDto, Publisher>();
            CreateMap<PublisherResponseDto, Publisher>();
        }
    }
}
