using AutoMapper;
using Library.Domain;
using Library.DTOs;

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
