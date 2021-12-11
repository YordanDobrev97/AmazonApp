namespace AmazonSystem.Data.Models
{
    public class ShipmentItem
    {
        public int ShipmentItemId { get; set; }

        public int OrderItemId { get; set; }

        public OrderItem OrderItem { get; set; }

        public int Quantity { get; set; }
    }
}
