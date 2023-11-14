using AutoMapper;
using Biblioteka.Models;
using Biblioteka.Models.DTOs;

namespace Biblioteka.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewResponseDto>();
        }
    }
}
