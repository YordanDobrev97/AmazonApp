using System.ComponentModel.DataAnnotations;

namespace AmazonSystem.Web.ViewModels
{
    public class PaymentInputModel
    {
        public string ShippingMethod { get; set; }

        // Billing Address
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The field Street must be with a minimum length of 3 and a maximum length of 50")]
        public string Street { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "The field City must be with a minimum length of 3 and a maximum length of 30")]
        public string City { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "The field Country must be with a minimum length of 5 and a maximum length of 30")]
        public string Country { get; set; }

        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "The field Zip Code must be valid zip code")]
        public string ZipCode { get; set; }

        // Paypal
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The field PaypalName must be with a minimum length of 5 and a maximum length of 30")]
        public string PaypalName { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "The field PaypalEmail must be with a minimum length of 5 and a maximum length of 30")]
        public string PaypalEmail { get; set; }


        //Credit card
        [Display(Name = "Card Number")]
        [StringLength(30, MinimumLength = 5,ErrorMessage = "The field CardNumber must be with a minimum length of 5 and a maximum length of 30")]
        public string CardNumber { get; set; }

        [Display(Name = "Card Date")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "The field CardDate must be at valid format - MM/YY")]
        public string CardDate { get; set; }

        [Display(Name = "CVV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "The field CVV must be with length of 3")]
        public string Cvv { get; set; }

        [Display(Name = "Card Name")]
        [RegularExpression(@"^[^\s]+( [^\s]+)+$", ErrorMessage = "The field CardName must be with First Name and Last Name")]
        public string CardName { get; set; }
    }
}
