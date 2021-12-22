using System.Collections.Generic;

namespace AmazonSystem.Products.ViewModels
{
    public class ProductViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public List<ProductByCategoryViewModel> Products { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
