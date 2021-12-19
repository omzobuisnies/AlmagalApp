using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Models.Entities
{
    public class Invoice:BaseEntity
    {
        public int InvoiceCode { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]public Customer Customer { get; set; }
        public virtual ICollection<InvoiceDetails> Details { get; set; }
    }
}
