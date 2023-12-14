using Library.API.Data.Abstract;
using Library.Domain;
using Library.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete;

public class RentalRepository : IRentalRepository
{
    private readonly LibraryDbContext _context;

    public RentalRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Rental>> GetRents(int? id = null)
    {
        var rents = await _context.Rentals.Include(r => r.Book).Include(r => r.User)
            .Where(r => id == null || r.UserId == id)
            .ToListAsync();
        return rents;
    }

    public async Task<Rental> GetRent(int id)
    {
        var rent = await _context.Rentals.Include(r => r.Book).Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);
        if(rent is null) throw new Exception("Rent not found");
        return rent;
    }

    public async Task<Rental> CreateRent(RentCreateDto rent)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == rent.BookId);
        if(book is null) throw new Exception("Book not found");
        
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == rent.UserId);
        if(user is null) throw new Exception("User not found");
        
        Rental newRent = new()
        {
            BookId = rent.BookId,
            UserId = rent.UserId,
            RentalDate = DateTime.Now.ToString("dd/MM/yyyy"),
            ReturnDate = string.Empty
        };
        _context.Rentals.Add(newRent);
        await _context.SaveChangesAsync();
        return newRent;
    }

    public async Task<Rental> UpdateRent(RentResponseDto rent)
    {
        var rentToUpdate = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == rent.Id);
        if (rentToUpdate is null) throw new Exception("Rent not found");
        rentToUpdate.ReturnDate = DateTime.Now.ToString("dd/MM/yyyy");
        _context.Rentals.Update(rentToUpdate);
        await _context.SaveChangesAsync();
        return rentToUpdate;
    }
}