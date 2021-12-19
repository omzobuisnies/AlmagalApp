using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Models.DTO
{
    public class CustomerViewModel : BaseViewModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
    }
    public class CustomerViewModelResponse
    {
        public CustomerViewModel Customer { get; set; }
        public ResponseVModel response { get; set; }
    }
    public class CustomerViewModelsResponse
    {
        public List<CustomerViewModel> Customers { get; set; }
        public ResponseVModel response { get; set; }
    }
}
