using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Models.DTO
{
    public class ResponseVModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public string Info { get; set; }
    }
}
