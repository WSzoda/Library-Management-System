﻿using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models.DTOs
{
    public class CountryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
