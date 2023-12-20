using Library.Blazor.Services.ReviewsService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Comps;

partial class ReviewModal
{
    [Parameter]
    public Action<ReviewResponseDto>? OnReviewAdded { get; set; }
    
    [Parameter]
    public int _bookId { get; set; }
    
    [Inject]
    private IReviewService? ReviewService { get; set; }
    
    [Inject]
    NotificationService NotificationService { get; set; }
    
    private string _description = default!;
    private int _rating = default!;
    private bool _isOpen;
    private string _modalButtonsText = "Add Review";
    
    private async Task HandleSubmit()
    {
        var review = new ReviewCreateDto { Description = _description, Rating = _rating, BookId = _bookId};
        try
        {
            var newReview = await ReviewService!.AddReviewAsync(_bookId, review);
            OnReviewAdded?.Invoke(newReview);
            NotificationService.Notify(NotificationSeverity.Success, "Success", "Review added successfully!");
        }
        catch (Exception e)
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Review could not be added!");
            Console.WriteLine(e.Message);
        }
        finally
        {
            CloseModal();
        }
    }

    private void CloseModal()
    {
        _isOpen = false;
    }
    
    private void OpenModal()
    {
        _isOpen = true;
    }

}