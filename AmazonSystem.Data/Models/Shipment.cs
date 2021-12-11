using System;
using System.Collections.Generic;

namespace AmazonSystem.Data.Models
{
    public class Shipment
    {
        public Shipment()
        {
            this.ShipmentItems = new HashSet<ShipmentItem>();
        }

        public int ShipmentId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public string TrackingNumber { get; set; }

        public decimal TotalWeight { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public ICollection<ShipmentItem> ShipmentItems { get; set; }
    }
}
