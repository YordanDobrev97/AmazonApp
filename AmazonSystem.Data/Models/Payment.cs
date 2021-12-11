namespace AmazonSystem.Data.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public bool IsValidPayment { get; set; }
    }
}
