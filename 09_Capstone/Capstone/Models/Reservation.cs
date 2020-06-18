using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Reservation
    {
        public int Reservation_Id { get; set; }
        public int Site_Id { get; set; }
        public int Name { get; set; }
        public int From_Date { get; set; }
        public int To_Date { get; set; }
        public int Create_Date { get; set; }

        public override string ToString()
        {
            return $"{Reservation_Id} {Site_Id} {Name} {From_Date} {To_Date} {Create_Date}";
        }
    }
}
