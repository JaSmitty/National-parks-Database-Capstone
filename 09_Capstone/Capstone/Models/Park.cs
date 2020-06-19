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
        public int Vistors { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Park_Id, 10}  {Name, -10} \n {Location, 30} {Establish_Date.ToString("M/d/yyyy"), -10} \n {Area, 20} {Vistors, -10} {Description, 10:N0}";
        }

    }
}
