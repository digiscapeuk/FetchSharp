using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchSharp.Models
{
    public class ForumThread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Posts { get; set; }
        public string Category { get; set; }
        public DateTime LastPost { get; set; }
    }
}
