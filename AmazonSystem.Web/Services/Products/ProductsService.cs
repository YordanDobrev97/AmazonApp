using AmazonSystem.Products.Repository;
using AmazonSystem.Products.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<ProductViewModel> All(int id)
        {
            var products = await this.productsRepository.All(id);
            return products;
        }

        public async Task Add(string name, string imageUrl, string description, int quantity, decimal price, string category)
        {
            await this.productsRepository.Add(name, imageUrl, description, quantity, price, category);
        }

        public async Task<ProductDetailsViewModel> Details(int id)
        {
            var product = await this.productsRepository.Details(id);
            return product;
        }

        public async Task Delete(int id)
        {
            await this.productsRepository.Delete(id);
        }
    }
}
