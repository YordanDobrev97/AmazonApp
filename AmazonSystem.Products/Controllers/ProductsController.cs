using AmazonSystem.Data.Models;
using AmazonSystem.Products.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Products.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await this.productsRepository.All();
            return products;
        }

        public async Task Add(Product product)
        {
            await this.productsRepository.Add(product);
        }
    }
}
