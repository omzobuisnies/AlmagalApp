using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Models.Entities
{
    public class InvoiceDetails:BaseEntity
    {
        public string InvoiceId { get; set; }
        [ForeignKey(nameof(InvoiceId))] public Invoice Invoice { get; set; }
        public string ProductId { get; set; }
        [ForeignKey(nameof(ProductId))] public Product Product { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }
}
