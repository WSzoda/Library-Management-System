using Library.Blazor.Services.LanguageService;
using Library.Blazor.Services.PublisherService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Pages.Publishers;

partial class PublishersHome
{
    [Inject]
    private IPublisherService? PublisherService { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }

    private bool _isLoading = true;
    private IEnumerable<PublisherResponseDto> _publishers = new List<PublisherResponseDto>();

    protected override async Task OnInitializedAsync()
    {
        _publishers = await PublisherService!.GetPublishersAsync();
        _isLoading = false;
    }

    private void AddPublisher(PublisherResponseDto publisher)
    {
        var newPublishers = _publishers.ToList();
        newPublishers.Add(publisher);
        _publishers = newPublishers;
        StateHasChanged();
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Publisher added");
    }

    public void EditPublisher(PublisherResponseDto publisher)
    {
        var publisherObj = _publishers.First(l => l.Id == publisher.Id);
        publisherObj.Name = publisher.Name;
        publisherObj.YearOfCreation = publisher.YearOfCreation;
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Publisher edited.");
        StateHasChanged();
    }

    async Task DeletePublisher(PublisherResponseDto publisher)
    {
        try
        {
            _publishers = _publishers.Where(p => p.Id != publisher.Id).ToList();
            NotificationService.Notify(NotificationSeverity.Success, "Success", "Publisher deleted.");
            StateHasChanged();
        }
        catch (Exception e)
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Something went wrong, try again.");
            Console.WriteLine(e);
        }
    }
}