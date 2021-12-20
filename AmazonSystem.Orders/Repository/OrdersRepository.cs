using AmazonSystem.Common;
using AmazonSystem.Data;
using AmazonSystem.Data.Models;
using AmazonSystem.Orders.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> Create(CreateOrderViewModel model)
        {
            bool isParseShippingMethodEnum = Enum.TryParse(model.ShippingMethod, true, out ShippingMethod shippingMethod);

            if (!isParseShippingMethodEnum)
            {
                return GlobalConstants.OrderStatusCode;
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

            return newOrder.Id;
        }

        public Task<OrderDetailsViewModel> Details(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AllOrdersViewModel> GetUserOrders(string userId, int id)
        {
            var max = GlobalConstants.MaxListOrders;
            int skip = (id - 1) * max;

            var orders = await this.dbContext.OrderItems
                .Where(x => x.Order.CustomerId == userId)
                .Skip(skip)
                .Take(max)
                .Include(x => x.Product.Category)
                .Select(x => new UserOrdersViewModel()
                {
                    Product = x.Product,
                    Order = x.Order,
                })
                .ToListAsync();

            var viewModel = new AllOrdersViewModel()
            {
                Orders = orders,
                CurrentPage = id,
                PagesCount = (int)Math.Ceiling(this.dbContext.Orders.Count() / (decimal)max),
            };

            return viewModel;
        }
    }
}
