﻿using System.ComponentModel.DataAnnotations;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage ="Stock is required")]
        public long Stock { get; set; }
        public string? ImageURL { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
