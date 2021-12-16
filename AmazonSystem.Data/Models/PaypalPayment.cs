using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonSystem.Data.Models
{
    public class PaypalPayment
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string CustommerId { get; set; }

        public ApplicationUser Customer { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
