using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Biblioteka.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherResponseDto>();
        }
    }
}
