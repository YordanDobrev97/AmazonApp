using AmazonSystem.Products.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Products.Repository
{
    public interface IProductsRepository
    {
        Task<ProductViewModel> All(int id);

        Task Add(string name, string imageUrl, string description, int quantity, decimal price, string category);

        Task<ProductDetailsViewModel> Details(int id);

        Task Delete(int id);

        Task<ProductEditViewModel> Edit(int id);

        Task Update(ProductEditViewModel product);

        Task<ListProductViewModel> SearchByCategory(int id, string category);
    }
}
