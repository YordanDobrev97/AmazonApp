namespace AmazonSystem.Web.ViewModels
{
    public class PaymentInputModel
    {
        public string ShippingMethod { get; set; }

        // Billing Address
        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        // Paypal
        public string PaypalName { get; set; }

        public string PaypalEmail { get; set; }


        //Credit card
        public string CardNumber { get; set; }

        public string CardDate { get; set; }

        public string Cvv { get; set; }

        public string CardName { get; set; }
    }
}
