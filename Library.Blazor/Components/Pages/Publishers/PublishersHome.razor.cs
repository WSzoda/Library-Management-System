using Library.Blazor.Services.LanguageService;
using Library.Blazor.Services.PublisherService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Publishers;

partial class PublishersHome
{
    [Inject]
    private IPublisherService? PublisherService { get; set; }
    
    private bool _isLoading = true;
    private IEnumerable<PublisherResponseDto> _publishers = new List<PublisherResponseDto>();

    protected override async Task OnInitializedAsync()
    {
        _publishers = await PublisherService!.GetPublishersAsync();
        _isLoading = false;
    }
    
    private void AddPublisher(PublisherResponseDto publisher)
    {
        _publishers.ToList().Add(publisher);
    }
    
    void EditPublisher(PublisherResponseDto publisher)
    {
        var publisherObj = _publishers.First(l => l.Id == publisher.Id);
        publisherObj.Name = publisher.Name;
        publisherObj.YearOfCreation = publisher.YearOfCreation;
        StateHasChanged();
    }

    async void DeletePublisher(PublisherResponseDto publisher)
    {
        await PublisherService!.DeletePublisherAsync(publisher.Id);
        _publishers.ToList().RemoveAll(l => l.Id == publisher.Id);
        StateHasChanged();
    }
}