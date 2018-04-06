using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchSharp.Models
{
    public class TrainingEntry
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int Id { get; set; }
        public double Miles { get; set; }
        public string SubCategory { get; set; }
        public TimeSpan Time { get; set; }
    }
}
