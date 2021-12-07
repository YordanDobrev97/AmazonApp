using AmazonSystem.Products.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Products.Repository
{
    public interface IProductsRepository
    {
        Task<List<ListProductViewModel>> All();

        Task Add(string name, string imageUrl, string description, int quantity, decimal price, string category);
    }
}
