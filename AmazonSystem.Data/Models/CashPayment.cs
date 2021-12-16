using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonSystem.Data.Models
{
    public class CashPayment
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string CustommerId { get; set; }

        public ApplicationUser Customer { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
