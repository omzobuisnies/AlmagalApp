using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Models.DTO
{
    public class ProductViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class ProductViewModelResponse
    {
        public ProductViewModel Product { get; set; }
        public ResponseVModel response { get; set; }
    }
    public class ProductViewModelsResponse
    {
        public List<ProductViewModel> Products { get; set; }
        public ResponseVModel response { get; set; }
    }
}
