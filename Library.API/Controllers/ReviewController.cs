using System.Net;
using System.Security.Claims;
using AutoMapper;
using Library.API.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/reviews")]
[ApiController]
[Authorize]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<ReviewResponseDto>> AddReview(int id, ReviewCreateDto reviewCreateDto)
    {
        try
        {
            var user = HttpContext.User;
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var review = _mapper.Map<Review>(reviewCreateDto);
            review.UserId = int.Parse(userId!);
            review.BookId = id;
            review.Rating = review.Rating switch
            {
                > 5 => 5,
                < 1 => 1,
                _ => review.Rating
            };

            await _reviewRepository.AddReview(review);
            var reviewResponseDto = _mapper.Map<ReviewResponseDto>(review);
            return Ok(reviewResponseDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}