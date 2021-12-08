﻿namespace AmazonSystem.Products.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public bool InStock { get; set; }

        public string Description { get; set; }
    }
}
