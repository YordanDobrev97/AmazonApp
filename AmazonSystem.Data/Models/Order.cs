using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonSystem.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public DateTime OrderDate { get; set; }

        public ShippingStatus ShippingStatus { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
