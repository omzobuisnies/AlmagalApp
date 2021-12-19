using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Models.DTO
{
    public class BaseViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? DeletedDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
