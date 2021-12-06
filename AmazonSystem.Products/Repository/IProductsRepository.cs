using AmazonSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Products.Repository
{
    public interface IProductsRepository
    {
        Task<List<Product>> All();

        Task Add(Product product);
    }
}
