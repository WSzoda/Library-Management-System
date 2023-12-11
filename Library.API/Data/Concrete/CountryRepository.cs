using Library.API.Data.Abstract;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete;

public class CountryRepository : ICountryRepository
{
    private readonly LibraryDbContext _context;

    public CountryRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Country>> GetAllCountries(string? countryNameFilter = "")
    {
        var query = _context.Countries
            .AsNoTracking()
            .AsSplitQuery();

        if (!string.IsNullOrWhiteSpace(countryNameFilter))
        {
            query = query.Where(c => string.Equals(c.Name.ToLower(), countryNameFilter.ToLower()));
        }
        var countries = await query.ToListAsync();
        return countries;
    }
    
    public async Task<Country?> GetCountryById(int id)
    {
        var country = await _context.Countries
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return country;
    }
    
    public async Task AddCountry(Country country)
    {
        ArgumentNullException.ThrowIfNull(country);

        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
    }
}