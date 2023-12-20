using AutoMapper;
using Library.Domain;
using Library.DTOs;

namespace Library.API.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewResponseDto>();
            CreateMap<ReviewCreateDto, Review>();
        }
    }
}
