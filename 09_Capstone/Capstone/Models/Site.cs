using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    class Site
    {
        public int Site_Id { get; set; }
        public int Campground_Id { get; set; }
        public int Site_Number { get; set; }
        public int Max_Occupancy { get; set; }
        public int Accessible { get; set; }
        public int Max_Rv_Length { get; set; }
        public int Utilities { get; set; }

        public override string ToString()
        {
            return $"{Site_Id} {Campground_Id} {Site_Number} {Max_Occupancy} {Accessible} {Max_Rv_Length} {Utilities}";
        }
    }
}
