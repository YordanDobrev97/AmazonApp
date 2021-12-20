using AmazonSystem.Web.Services.Orders;
using AmazonSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task<IActionResult> Index(int id = 1)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = await this.ordersService.GetUserOrders(userId, id);
            return View(viewModel);
        }
    }
}
