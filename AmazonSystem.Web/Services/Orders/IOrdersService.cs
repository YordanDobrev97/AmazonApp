using AmazonSystem.Orders.ViewModels;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Services.Orders
{
    public interface IOrdersService
    {
        Task<int> Create(CreateOrderViewModel model);

        Task<OrderDetailsViewModel> Details(int orderId);
    }
}
