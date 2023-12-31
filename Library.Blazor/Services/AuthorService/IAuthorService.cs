﻿using Library.DTOs;

namespace Library.Blazor.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseDto>> GetAuthorsAsync();
        Task<AuthorResponseDto> GetAuthorByIdAsync(int id);
        Task<AuthorResponseDto> AddAuthorAsync(AuthorCreateDto author);
        Task<AuthorResponseDto> EditAuthorAsync(int id, AuthorResponseDto authorUpdateDto);
        Task DeleteAuthorAsync(int id);
    }
}
