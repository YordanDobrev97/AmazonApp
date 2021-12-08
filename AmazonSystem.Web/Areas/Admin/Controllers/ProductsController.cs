using AmazonSystem.Products.Repository;
using AmazonSystem.Web.Services.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await this.productsService.All();
            return this.View(products);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task Add(string name, string imageUrl, string description, int quantity, decimal price, string category)
        {
            await this.productsService.Add(name, imageUrl, description, quantity, price, category);
            this.RedirectToAction("Index", "Products");
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productsService.Details(id);
            return this.View(product);
        }
    }
}
