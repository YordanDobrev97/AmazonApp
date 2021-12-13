﻿using AmazonSystem.Orders.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonSystem.Orders.Repository
{
    public interface IOrdersRepository
    {
        Task<bool> Create(CreateOrderViewModel model);

        Task<OrderDetailsViewModel> Details(int orderId);
    }
}
