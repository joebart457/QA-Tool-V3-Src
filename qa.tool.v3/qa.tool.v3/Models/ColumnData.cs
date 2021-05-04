using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Tool_Standalone.Models
{
    public class ColumnData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public ColumnData(string name, string data)
        {
            this.Name = name;
            this.Data = data;
        }

        public ColumnData(int id, string name, string data)
        {
            this.Id = id;
            this.Name = name;
            this.Data = data;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
