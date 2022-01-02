using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonSystem.Data.Models
{
    public class SaleProduct
    {
        public SaleProduct()
        {
            this.SaleProducts = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public int SaleId { get; set; }

        public Sale Sale { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public bool IsSuccess { get; set; }

        public ICollection<Product> SaleProducts { get; set; }
    }
}
