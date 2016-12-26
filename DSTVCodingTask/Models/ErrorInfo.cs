using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSTVCodingTask.Models
{
    public class ErrorInfo
    {
        public string ElementName { get; set; }

        public string Symbol { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}