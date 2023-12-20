using Library.Blazor.Services.RentService;
using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Comps;

partial class RentModal
{
    
    [Parameter]
    public BookResponseDto? BookToRent { get; set; }
    
    [Inject]
    private IRentService? RentService { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }
    
    private bool _isOpen;
    
    private async Task HandleSubmit()
    {
        try
        {
            await RentService!.RentBook(BookToRent!);
        }
        catch (Exception e)
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Something went wrong, try again.");
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