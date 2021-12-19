using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Models.DTO
{
    public class InvoiceVModel:BaseViewModel
    {
        public int InvoiceCode { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public virtual ICollection<InvoiceDetailsVModel> Details { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class CreateInvoiceVModel
    {
        public string CustomerId { get; set; }
        public virtual ICollection<CreateInvoiceDetailsVModel> Details { get; set; }

    }
    public class InvoiceVModelResponse
    {
        public InvoiceVModel Invoice { get; set; }
        public ResponseVModel response { get; set; }
    }
    public class InvoiceVModelsResponse
    {
        public List<InvoiceVModel> invoice { get; set; }
        public ResponseVModel response { get; set; }
    }
}
