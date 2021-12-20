using AmazonSystem.Orders.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Services.Orders
{
    public interface IOrdersService
    {
        Task<int> Create(CreateOrderViewModel model);

        Task<OrderDetailsViewModel> Details(int orderId);

        Task<AllOrdersViewModel> GetUserOrders(string userId, int id);
    }
}
