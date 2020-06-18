using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Park
    {
        public int Park_Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Establish_Date { get; set; }
        public int Area { get; set; }
        public string Vistors { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Park_Id} {Name} {Location} {Establish_Date} {Area} {Vistors} {Description}";
        }
    }
}
