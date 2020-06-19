using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Campground
    {
        public int Campground_Id { get; set; }
        public int Park_Id  { get; set; }
        public string Name { get; set; }
        public int Open_From_Mm { get; set; } //TODO convert numerical values into Date strings
        public int Open_To_Mm { get; set; }
        public decimal Daily_Fee { get; set; }

        public string MonthNumberToName(int monthCoverter)
        {
            Dictionary<int, string> monthDictionary = new Dictionary<int, string>()
            {
                { 1, "January" },
                { 2, "February" },
                { 3, "March" },
                { 4, "April" },
                { 5, "May" },
                { 6, "June" },
                { 7, "July" },
                { 8, "August" },
                { 9, "September" },
                { 10, "October" },
                { 11, "November" },
                { 12, "December" },
            };

            return monthDictionary[monthCoverter];

        }

        public override string ToString()
        {
            return $"{Campground_Id} {Park_Id} {Name} {MonthNumberToName(Open_From_Mm)} {MonthNumberToName(Open_To_Mm)} {Daily_Fee}";
        }
    }
}
