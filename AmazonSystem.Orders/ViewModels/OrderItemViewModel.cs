using AmazonSystem.Data.Models;
using System.Collections.Generic;

namespace AmazonSystem.Orders.ViewModels
{
    public class OrderItemViewModel
    {
        public ICollection<OrderProductViewModel> OrderProducts { get; set; }
    }
}
