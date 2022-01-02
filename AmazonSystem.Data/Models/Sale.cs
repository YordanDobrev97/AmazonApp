using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonSystem.Data.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
    }
}
