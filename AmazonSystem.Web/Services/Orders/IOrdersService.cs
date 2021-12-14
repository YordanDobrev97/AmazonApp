using AmazonSystem.Orders.ViewModels;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Services.Orders
{
    public interface IOrdersService
    {
        Task<bool> Create(CreateOrderViewModel model);

        Task<OrderDetailsViewModel> Details(int orderId);
    }
}
