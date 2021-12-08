using System.Collections.Generic;

namespace AmazonSystem.Products.ViewModels
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public List<string> Categories { get; set; }
    }
}
