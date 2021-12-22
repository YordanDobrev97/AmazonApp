using AmazonSystem.Web.Areas.Admin.ViewModels;
using AmazonSystem.Web.Services.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Areas.Admin.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductsService productsService;

        public SearchController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Route("api/[controller]/SearchByCategory")]
        public async Task<IActionResult> SearchByCategory([FromBody] CategorySearchViewModel inputModel)
        {
            var products = await this.productsService.SearchByCategory(1, inputModel.Category);
            return new JsonResult(products);
        }
    }
}
