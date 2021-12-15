using AmazonSystem.Common;
using AmazonSystem.Common.Services.Addresses;
using AmazonSystem.Common.Services.Users;
using AmazonSystem.Orders.ViewModels;
using AmazonSystem.Web.Services.Orders;
using AmazonSystem.Web.Services.Payments;
using AmazonSystem.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly IUsersService usersService;
        private readonly IPaymentsService paymentsService;
        private readonly IAddressesService addressesService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ISession session;

        public PaymentsController(
            IOrdersService ordersService,
            IUsersService usersService,
            IPaymentsService paymentsService,
            IAddressesService addressesService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.ordersService = ordersService;
            this.usersService = usersService;
            this.paymentsService = paymentsService;
            this.addressesService = addressesService;
            this.httpContextAccessor = httpContextAccessor;
            this.session = this.httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pay(PaymentInputModel input)
        {
            var addressId = this.addressesService.IsExist(input?.Street, input?.City, input?.Country);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (input.ShippingMethod == "Cash" && addressId == GlobalConstants.InvalidAddressStatusCode)
            {
                addressId = await this.addressesService.Create(input.Street, input.City, input.Country, input.ZipCode);
            }
            else
            {
                addressId = await this.usersService.GetAddress(userId);
            }

            var orderItems = this.GetCartItems();

            if (orderItems.Count == 0)
            {
                //TODO ...
                return this.View();
            }

            int orderId = await ordersService.Create(new CreateOrderViewModel()
            {
                ShippingMethod = input.ShippingMethod,
                AddressId = addressId,
                CustomerId = userId,
                OrderItems = orderItems
            });
            
            if (orderId == GlobalConstants.OrderStatusCode)
            {
                // TODO ...
            }

            bool isSuccessPayment = await this.paymentsService.Pay(orderId);

            if (!isSuccessPayment)
            {
                // TODO ...
            }

            return this.RedirectToAction("Index", "Home");
        }

        private List<OrderProductViewModel> GetCartItems()
        {
            var productItems = session.GetString(GlobalConstants.SessionKey);
            if (productItems == null)
            {
                productItems = "[]";
            }

            var cartItems = JsonConvert.DeserializeObject<List<OrderProductViewModel>>(productItems);
            return cartItems;
        }
    }
}
