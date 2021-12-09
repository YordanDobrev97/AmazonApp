using AmazonSystem.Web.Services.Products;
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

        public async Task<IActionResult> ProductsByCategory(string category)
        {
            var products = await this.productsService.SearchByCategory(category);
            return this.View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productsService.Details(id);
            return this.View(product);
        }
    }
}
