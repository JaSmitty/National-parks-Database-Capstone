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
        public bool Accessible { get; set; }
        public int Max_Rv_Length { get; set; }
        public bool Utilities { get; set; }

        public override string ToString() // TODO Fix this formatting
        {
            
            return $"|{Site_Id,-5}| {Max_Occupancy,-15}| {(Accessible ? "Yes" : "No"),-10}|{RvLengthConverter(Max_Rv_Length),-15}| {(Utilities ? "Yes" : "N/A"),-5}|";
        }

        public static string GetHeader()
        {
            return $@"{"Site Id",-5} {"Max Occupancy",-15} {"Accessible?",-10} {"Max Rv Length",-15} {"Utilities",-5} {"Cost",-5}" ;
        }
        public string RvLengthConverter(int numberToBeConverted)
        {
            if(numberToBeConverted == 0)
            {
                return "N/A";
            }
            return numberToBeConverted.ToString() ;
        }


    }
}
