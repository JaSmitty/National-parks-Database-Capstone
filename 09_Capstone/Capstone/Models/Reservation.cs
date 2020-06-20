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
        public DateTime From_Date { get; set; }
        public DateTime To_Date { get; set; }
        public DateTime Create_Date { get; set; } //not sure if string or DateTime?

        public override string ToString()
        {
            return $"{Reservation_Id} {Site_Id} {Name} {From_Date} {To_Date} {Create_Date}";
        }
    }
}
