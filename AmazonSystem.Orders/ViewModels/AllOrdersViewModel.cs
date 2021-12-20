using AmazonSystem.Orders.ViewModels;
using System.Collections.Generic;

namespace AmazonSystem.Orders.ViewModels
{
    public class AllOrdersViewModel
    {
        public List<UserOrdersViewModel> Orders { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
