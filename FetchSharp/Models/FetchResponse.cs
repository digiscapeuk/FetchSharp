using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchSharp.Models
{
    public class FetchResponse<T>
    {
        public string Request { get; set; }
        public string Outcome { get; set; }
        public List<T> Response { get; set; }
    }
}
