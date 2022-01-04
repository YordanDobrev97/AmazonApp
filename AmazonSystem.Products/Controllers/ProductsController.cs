using AmazonSystem.Data.Models;
using AmazonSystem.Products.Repository;
using AmazonSystem.Products.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Products.Controllers
{
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        [Route("api/Products/Test/{id}/{category}")]
        public ActionResult Test(int id, string category)
        {
            return new JsonResult("It works! " + id + " Category: " + category);
        }

        [HttpGet]
        [Route("api/Products/SearchByCategory/{id}/{category}")]
        public async Task<JsonResult> SearchByCategory(int id, string category)
        {
            var response = await this.productsRepository.SearchByCategory(id, category);
            return new JsonResult(response);
        }
    }
}
