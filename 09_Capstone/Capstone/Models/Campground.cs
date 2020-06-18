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

        public override string ToString()
        {
            return $"{Campground_Id} {Park_Id} {Name} {Open_From_Mm} {Open_To_Mm} {Daily_Fee}";
        }
    }
}
