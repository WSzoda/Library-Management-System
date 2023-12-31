﻿using Library.Domain;

namespace Library.API.Data.Abstract;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllCountries(string? countryNameFilter = "");
    public Task AddCountry(Country country);
    public Task<Country?> GetCountryById(int id);
    Task<Country> EditCountry(int id, Country country);
    Task DeleteCountry(int id);
}