namespace AlmagalApp.Models.DTO
{
    public class InvoiceDetailsVModel:BaseViewModel
    {
        public string InvoiceId { get; set; }
        public string ProductId { get; set; }
        public string Product { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }

    }
    public class CreateInvoiceDetailsVModel
    {
        public string ProductId { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }
}