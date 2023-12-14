using Library.Blazor.Services.RentService;
using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class RentModal
{
    
    [Parameter]
    public BookResponseDto? BookToRent { get; set; }
    
    [Inject]
    private IRentService? RentService { get; set; }
    
    private bool _isOpen;
    
    private async Task HandleSubmit()
    {
        try
        {
            await RentService!.RentBook(BookToRent!);
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