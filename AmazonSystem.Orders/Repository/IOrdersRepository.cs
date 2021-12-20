using AmazonSystem.Orders.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Orders.Repository
{
    public interface IOrdersRepository
    {
        Task<int> Create(CreateOrderViewModel model);

        Task<OrderDetailsViewModel> Details(int orderId);

        Task<AllOrdersViewModel> GetUserOrders(string userId, int id);
    }
}
