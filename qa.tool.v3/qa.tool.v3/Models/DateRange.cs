using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Tool_Standalone.Models
{
    class DateRange
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public override string ToString()
        {
            return $"{this.Label}    |    {this.StartTime.ToString()} - {this.EndTime.ToString()}";
        }
    }
}
