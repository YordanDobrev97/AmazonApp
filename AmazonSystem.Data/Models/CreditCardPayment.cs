using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonSystem.Data.Models
{
    public class CreditCardPayment
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string CustommerId { get; set; }

        public ApplicationUser Customer { get; set; }

        public string CardNumber { get; set; }

        public string CardExpires { get; set; }

        public int CvvCode { get; set; }

        public string NameOfCard { get; set; }
    }
}
