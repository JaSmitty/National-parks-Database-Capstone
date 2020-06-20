using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Site
    {
        public int Site_Id { get; set; }
        public int Campground_Id { get; set; }
        public int Site_Number { get; set; }
        public int Max_Occupancy { get; set; }
        public int Accessible { get; set; }
        public int Max_Rv_Length { get; set; }
        public int Utilities { get; set; }

        public override string ToString() // TODO Fix this formatting
        {
            return $"SiteID: {Site_Id} CampgroundID: {Campground_Id} SiteNumber{Site_Number} Occupancy: {Max_Occupancy} Accesible: {Accessible} MaxRvLength{Max_Rv_Length} Utilities: {Utilities}";
        }
    }
}
