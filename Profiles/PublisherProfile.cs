using AutoMapper;
using Biblioteka.Models;
using Biblioteka.Models.DTOs;

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
