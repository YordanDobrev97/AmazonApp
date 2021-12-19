using AmazonSystem.Orders.Repository;
using AmazonSystem.Orders.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<int> Create(CreateOrderViewModel model)
        {
            return await this.ordersRepository.Create(model);
        }

        public async Task<OrderDetailsViewModel> Details(int orderId)
        {
            return await this.ordersRepository.Details(orderId);
        }

        public async Task<List<UserOrdersViewModel>> GetUserOrders(string userId)
        {
            return await this.ordersRepository.GetUserOrders(userId);
        }
    }
}
