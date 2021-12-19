using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Models.Entities
{
    public class Customer:BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
