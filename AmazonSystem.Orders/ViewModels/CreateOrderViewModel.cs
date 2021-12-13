using System.Collections.Generic;

namespace AmazonSystem.Orders.ViewModels
{
    public class CreateOrderViewModel
    {
        public string CustomerId { get; set; }

        public int AddressId { get; set; }

        public string ShippingMethod { get; set; }

        public ICollection<OrderProductViewModel> OrderItems { get; set; }
    }
}
