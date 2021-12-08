using AmazonSystem.Products.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Services.Products
{
    public interface IProductsService
    {
        Task<ProductViewModel> All(int id);

        Task Add(string name, string imageUrl, string description, int quantity, decimal price, string category);

        Task<ProductDetailsViewModel> Details(int id);
    }
}
