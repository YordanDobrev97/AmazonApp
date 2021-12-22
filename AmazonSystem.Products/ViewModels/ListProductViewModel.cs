using System.Collections.Generic;

namespace AmazonSystem.Products.ViewModels
{
    public class ListProductViewModel
    {
        public string Category { get; set; }

        public List<ProductByCategoryViewModel> Products { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
