using System.Collections.Generic;

namespace AmazonSystem.Products.ViewModels
{
    public class ProductViewModel
    {
        public List<ListProductViewModel> Products { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
