using AmazonSystem.Products.ViewModels;
using AmazonSystem.Web.Services.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
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

        [HttpGet]
        public async Task<IActionResult> Index(int id = 1)
        {
            var data = await this.productsService.All(id);
            return this.View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name, string imageUrl, string description, int quantity, decimal price, string category)
        {
            await this.productsService.Add(name, imageUrl, description, quantity, price, category);
            return this.RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productsService.Details(id);
            return this.View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.productsService.Delete(id);
            return this.RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await this.productsService.Edit(id);
            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel product)
        {
            await this.productsService.UpdateAsync(product);
            return this.RedirectToAction("Details", "Products", new { id = product.Id });
        }
    }
}
