using Library.Domain;
using Library.DTOs;

namespace Library.API.Data.Abstract;

public interface IRentalRepository
{
    Task<IEnumerable<Rental>> GetRents(int? id = null, int? userId = null);
    Task<Rental> GetRent(int id);
    Task<Rental> CreateRent(RentCreateDto rent);
    Task<Rental> UpdateRent(RentResponseDto rent);
}