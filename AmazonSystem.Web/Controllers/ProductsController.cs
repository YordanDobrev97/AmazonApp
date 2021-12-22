using AmazonSystem.Web.Services.Products;
using AmazonSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> ProductsByCategory(ProductsByCategoryInputModel input)
        {
            var products = await this.productsService.SearchByCategory(input.Id, input.Category);
            return this.View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productsService.Details(id);
            return this.View(product);
        }
    }
}
