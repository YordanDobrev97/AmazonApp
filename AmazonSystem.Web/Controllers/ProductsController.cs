using AmazonSystem.Products.ViewModels;
using AmazonSystem.Web.Services.Products;
using AmazonSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly HttpClient client = new HttpClient();
        private readonly string BaseURL = "https://localhost:5001";

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsByCategory(ProductsByCategoryInputModel input)
        {
            // Continue http communication
            var response = await this.client.GetAsync($"{BaseURL}/api/Products/SearchByCategory/{input.Id}/{input.Category}");
            var responseViewModel  = await DeserializeResponseContent(response);
            return this.View(responseViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await this.productsService.Details(id);
            return this.View(product);
        }

        static async Task<ListProductViewModel> DeserializeResponseContent(HttpResponseMessage response)
        {
            var transactionResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ListProductViewModel>(transactionResult);
        }
    }
}
