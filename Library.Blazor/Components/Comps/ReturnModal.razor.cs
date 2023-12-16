using Library.Blazor.Services.RentService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class ReturnModal
{
    
    [Parameter]
    public BookResponseDto? BookToReturn { get; set; }
    
    [Inject]
    private IRentService? RentService { get; set; }
    
    private bool _isOpen;
    
    private async Task HandleSubmit()
    {
        try
        {
            await RentService!.ReturnBook(BookToReturn!);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
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