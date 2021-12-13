using AmazonSystem.Data;
using AmazonSystem.Data.Models;
using AmazonSystem.Orders.ViewModels;
using System;
using System.Threading.Tasks;

namespace AmazonSystem.Orders.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrdersRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Create(CreateOrderViewModel model)
        {
            bool isParseShippingMethodEnum = Enum.TryParse(model.ShippingMethod, true, out ShippingMethod shippingMethod);

            if (!isParseShippingMethodEnum)
            {
                return false;
            }

            var newOrder = new Order()
            {
                CustomerId = model.CustomerId,
                AddressId = model.AddressId,
                OrderDate = DateTime.UtcNow,
                ShippingMethod = shippingMethod,
                ShippingStatus = ShippingStatus.Shipped,
            };

            foreach (var item in model.OrderItems)
            {
                var orderItem = new OrderItem()
                {
                    Order = newOrder,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                newOrder.OrderItems.Add(orderItem);

                await this.dbContext.OrderItems.AddAsync(orderItem);
            }

            await this.dbContext.Orders.AddAsync(newOrder);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public Task<OrderDetailsViewModel> Details(int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}
